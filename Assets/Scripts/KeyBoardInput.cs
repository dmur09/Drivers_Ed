using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInput : MonoBehaviour
{
    public Car Car;


    // Update is called once per frame
    void Update()
    {
        if (Game.IsRunning())
        {
            if (Input.GetKey(KeyCode.W) && Car.deceleration > -0.07f)
            {
                Car.MoveManually(new Vector2(GameParameters.CarMoveAmount * Car.acceleration, 0f));
                if (Car.acceleration < GameParameters.MaxForwardSpeed)
                {
                    Car.acceleration += 0.035f;
                }
            }
            else if(Car.acceleration > 0) //changed so car decelerates on key release instead of stopping
            {
                Car.MoveManually(new Vector2(GameParameters.CarMoveAmount * Car.acceleration, 0f));
                Car.acceleration -= 0.07f;
                
            }

            if (Input.GetKey(KeyCode.S) && Car.acceleration < 0.07f)
            {
                Car.MoveManually(new Vector2(GameParameters.CarMoveAmount * Car.deceleration, 0f));
                if (Car.deceleration > GameParameters.MaxReverseSpeed)
                {
                    Car.deceleration -= 0.035f;
                }
            }
            else if(Car.deceleration < 0)
            {
                Car.MoveManually(new Vector2(GameParameters.CarMoveAmount * Car.deceleration, 0f));
                Car.deceleration += 0.07f;
            }
            
            if (Car.acceleration >= 0.035f)
            {
                if (Car.isDrunk == true) //disables key input if isDrunk is true
                    return;
                if (Input.GetKey(KeyCode.A))
                {
                    Car.transform.Rotate(0f, 0f, Car.acceleration/GameParameters.TurnSpeedScale); //changed it so turn speed scales with acceleration
                    Car.Exhaust.Play();
                    if (Car.acceleration >= 5.0f)
                    {
                        Car.Exhaust.Play();
                    }
                }
            
                if (Input.GetKey(KeyCode.D))
                {
                    Car.transform.Rotate(0f, 0f, -Car.acceleration/GameParameters.TurnSpeedScale);
                    Car.Exhaust.Play();
                    if (Car.acceleration >= 5.0f)
                    {
                        Car.Exhaust.Play();
                    }
                }
            }

            if (Car.deceleration <= -0.035f)
            {
                if (Car.isDrunk == true)
                    return;
                if (Input.GetKey(KeyCode.A))
                {
                    Car.transform.Rotate(0f, 0f, -Car.deceleration/GameParameters.TurnSpeedScale);
                    Car.Exhaust.Play();
                    if (Car.deceleration >= 5.0f)
                    {
                        Car.Exhaust.Play();
                    }
                }
            
                if (Input.GetKey(KeyCode.D))
                {
                    Car.transform.Rotate(0f, 0f, Car.deceleration/GameParameters.TurnSpeedScale);
                    Car.Exhaust.Play();
                    if (Car.deceleration >= 5.0f)
                    {
                        Car.Exhaust.Play();
                    }
                }
            }
        }
    }
}