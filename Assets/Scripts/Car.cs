using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public SpriteRenderer CarSpriteRenderer;
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
        
    }
    
    public void MoveManually(Vector2 direction)
    {
        Move(direction);
    }


    public void Move(Vector2 direction)
    {
        CarSpriteRenderer.transform.Translate(new Vector3(
            direction.x * GameParameters.CarMoveAmount,
            direction.y * GameParameters.CarMoveAmount, 
            0f));
    }
    
    /* public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == “StopSign”)
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

        if (col.gameObject.tag == “Beer”)
        {
            AutoStraight(); 
        }

        if (col.gameObject.tag == “Mushroom”)
        {
            ReplenishDamageGauge(); 
        }
    
        if (col.gameObject.tag == “PotLeaf”)
        {
            SlowDown(); 
        }

        if (col.gameObject.tag == “RedBull”)
        {
            SpeedUp(); 
        }
        
        if (col.gameObject.tag == “GuardRail”)
        {
            DamageGauge.Minus(1); 
        }
        Destroy(col.gameObject);
    } */
}
