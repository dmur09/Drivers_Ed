using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public SpriteRenderer CarSpriteRenderer;
    public float acceleration = 0.0f;
    public float deceleration = 0.0f;
    public ParticleSystem Exhaust;
    public Sounds Sounds;
    public bool isDrunk = false;

    void Update()
    {
        if (HasGameJustEnded())
        {
            Reset();
        }
    }

    private bool HasGameJustEnded()
    {
        if (!Game.IsRunning())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Reset()
    {
        ResetPosition();
        ResetRotation();
        isDrunk = false;
        acceleration = 0.0f;
        deceleration = 0.0f;
        DamageGauge.Replenish();
    }
    
    private void ResetPosition()
    {
        CarSpriteRenderer.transform.position = new Vector3(0f, 0f, 0f);

    }

    public void ResetRotation()
    {
        CarSpriteRenderer.transform.rotation = Quaternion.identity;
    }

    public void SetRotation()
    {
        CarSpriteRenderer.transform.Rotate(0, 0, 90);
    }
    
    public void MoveManually(Vector2 direction)
    {
        if (isDrunk == true)
            return;
        Move(direction);
    }


    public void Move(Vector2 direction)
    {
        CarSpriteRenderer.transform.Translate(new Vector2(
            direction.x, direction.y));
    }
    
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Beer")
        {
            AutoStraight();
            Sounds.PlayBeerSound();
            StartCoroutine(WaitToGetSober());
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "RedBull")
        {
            Sounds.PlayRedbullSound();
            SpeedUp();
            StartCoroutine(WaitForSpeedBuffToEnd());
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Pot Leaf")
        {
            Sounds.PlayWeedSound();
            SlowDown();
            StartCoroutine(WaitToSpeedUpAgain());
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Mushroom")
        {
            Sounds.PlayMushroomSound();
            DamageGauge.Replenish();
            print(DamageGauge.damage);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Pedestrian")
        {
            Sounds.PlayJailSound();
            //GoToJail();
            //DamageGauge.Minus(5);
            Game.EndGame();
        }
        
        if (col.gameObject.tag == "GuardRail")
        {
            Sounds.PlayGuardRailSound();
            DamageGauge.Minus(1);
            if (DamageGauge.damage <= 0)
            {
                Game.EndGame();
            }
        }
        
        if (col.gameObject.tag == "Silver Coin")
        {
            Sounds.PlayCoinSound();
            ScoreKeeper.Add(5);
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.tag == "Gold Coin")
        {
            Sounds.PlayCoinSound();
            ScoreKeeper.Add(1);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "StopSign")
        {
            StopAtSign();
            StartCoroutine(GoFromSign());
            DamageGauge.Minus(1); 
            Destroy(col.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "FinishLine")
        {
            GameParameters.Laps++;
            if (GameParameters.Laps == 3)
                Game.EndGame();
        }
    }

    private void StopAtSign()
    {
        GameParameters.CarMoveAmount = 0;
    }

    private void SlowDown()
    {
        if (acceleration > GameParameters.MaxForwardSpeed)
            acceleration = GameParameters.MaxForwardSpeed;
        GameParameters.MaxForwardSpeed /= 2;
        acceleration /= 2;
    }

    IEnumerator WaitToSpeedUpAgain()
    {
        yield return new WaitForSeconds(2);
        GameParameters.MaxForwardSpeed = 28.0f;

    }
    
    IEnumerator GoFromSign()
    {
        yield return new WaitForSeconds(1);
        GameParameters.CarMoveAmount = 0.015f;

    }

    private void AutoStraight()
    {
        isDrunk = true;
    }

    IEnumerator WaitToGetSober()
    {
        yield return new WaitForSeconds(1);
        isDrunk = false;
    }

    private void SpeedUp()
    {
        acceleration = 80.0f;
    }
    IEnumerator WaitForSpeedBuffToEnd()
    {
        yield return new WaitForSeconds(0.2f);
        if (acceleration > GameParameters.MaxForwardSpeed)
            acceleration = GameParameters.MaxForwardSpeed;
    }

    private void FixedUpdate()
    {
        if (isDrunk == true)
        {
            Move(new Vector2(0.3f, 0f));
        }
    }


}
