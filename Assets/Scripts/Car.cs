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
            Destroy(col.gameObject);
            StartCoroutine(GetSober());
        }
        if (col.gameObject.tag == "RedBull")
        {
            SpeedUp();
            Destroy(col.gameObject);
            StartCoroutine(WaitForSpeedBuffToEnd());
        }
        /*if (col.gameObject.tag == “StopSign”)
        {
            StopAtSign();
            DamageGauge.Minus(1); 
        }
    
        if (col.gameObject.tag == “SilverCoin”)
        {
            ScoreKeeper.Add(1);
        }

        if (col.gameObject.tag == “GoldCoin”)
        {
            ScoreKeeper.Add(5);
        }
    
        if (col.gameObject.tag == “Construction”)
        {
            StopAtConstruction();
            DamageGauge.Minus(1); 
        }
    
        if (col.gameObject.tag == “Pedestrian”)
        {
            GoToJail();
            DamageGauge.Minus(5); 
        }

        if (col.gameObject.tag == “Mushroom”)
        {
            ReplenishDamageGauge(); 
        }
    
        if (col.gameObject.tag == “PotLeaf”)
        {
            SlowDown(); 
        }

        
        
        if (col.gameObject.tag == “GuardRail”)
        {
            DamageGauge.Minus(1); 
        }
        Destroy(col.gameObject); */
    }

    private void AutoStraight()
    {
        isDrunk = true;
        acceleration = 5f;
    }

    IEnumerator GetSober()
    {
        yield return new WaitForSeconds(2);
        isDrunk = false;
    }

    private void SpeedUp()
    {
        acceleration = 60f;
    }
    IEnumerator WaitForSpeedBuffToEnd()
    {
        yield return new WaitForSeconds(2);
        if (acceleration > GameParameters.MaxForwardSpeed)
            acceleration = GameParameters.MaxForwardSpeed;
    }

    private void FixedUpdate()
    {
        if (isDrunk == true)
        {
            Move(new Vector2(0.5f, 0f));
        }
    }


}
