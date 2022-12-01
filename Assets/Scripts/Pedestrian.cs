using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public Crosswalk Crosswalk;
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


}
