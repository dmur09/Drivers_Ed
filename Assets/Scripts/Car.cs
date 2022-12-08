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
        acceleration = 0.0f;
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
            DamageGauge.Minus(5);
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.tag == "GuardRail")
        {
            Sounds.PlayGuardRailSound();
            DamageGauge.Minus(1);
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

        /*if (col.gameObject.tag == “StopSign”)
        {
            StopAtSign();
            DamageGauge.Minus(1); 
        }
    
        if (col.gameObject.tag == “Construction”)
        {
            StopAtConstruction();
            DamageGauge.Minus(1); 
        }
    
         */

    }

    private void SlowDown()
    {
        GameParameters.MaxForwardSpeed /= 2;
        if (acceleration > 18.0f)
            acceleration = 18.0f;
        acceleration /= 2;
    }

    IEnumerator WaitToSpeedUpAgain()
    {
        yield return new WaitForSeconds(2);
        GameParameters.MaxForwardSpeed = 7.0f;

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
        acceleration = 20f;
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
