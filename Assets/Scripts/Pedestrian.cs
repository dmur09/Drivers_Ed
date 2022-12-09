using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public GameObject ObjectPrefab;
    private float direction = 1;
    public float upperYLimit;
    public float lowerYLimit;
    public void Update()
    {
        if (Crosswalk.isCrosswalk == true)
        {
            PlaceOnCrosswalk();
            MoveOnCrosswalk();
        }
    }
    public void PlaceOnCrosswalk()
    {
        Vector3 location = RandomCrosswalkLocation();
        Instantiate(ObjectPrefab, location, Quaternion.identity);
    }
    public void MoveOnCrosswalk()
    {
        
    }

    public Vector3 RandomCrosswalkLocation()
    {
        return Vector3.back;
    }

    void FixedUpdate() //pedestrian moves up and down
    {
        if (Game.IsRunning())
        {
            ObjectPrefab.transform.Translate(new Vector2(0f, 0.1f*direction));
        }

        if (ObjectPrefab.transform.position.y > upperYLimit)
        {
            direction *= -1;
        }

        if (ObjectPrefab.transform.position.y < lowerYLimit)
        {
            direction *= -1;
        }
    }

}
