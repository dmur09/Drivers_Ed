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
            if (Input.GetKey(KeyCode.W))
            {
                Car.MoveManually(new Vector2(1f, 0f));
            }

            // rotate
            if (Input.GetKey(KeyCode.A))
            {
                Car.transform.Rotate(0f, 0f, 5f);
                // rotate
            }

            if (Input.GetKey(KeyCode.D))
            {
                Car.transform.Rotate(0f, 0f, -5f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                Car.MoveManually(new Vector2(-1f, 0f));
            }
        }
    }
}