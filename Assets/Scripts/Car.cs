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
        FaceCorrectDirection(direction);
        CarSpriteRenderer.transform.Translate(new Vector3(
            direction.x * GameParameters.CarMoveAmount,
            direction.y * GameParameters.CarMoveAmount, 
            0f));
    }

    
    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            CarSpriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            CarSpriteRenderer.flipX = true;

        }
        // make sprite face upwards and downwards
    }
}
