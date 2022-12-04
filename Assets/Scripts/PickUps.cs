using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : KeyBoardInput
{
    private int carSpeed; // speed of the car
    private int coinsCollected; //number of coins collected
    private int points;
    private int laps;
    public GameObject pickUp;
    public Car car;


    
    /*
    public void Mushroom()
    {
        //replenish damage gauge
    }

    public void PedestrianHit()
    {
        //if car collides with pedestrian, play Go To Jail Effect
    }

    public void CollectCoin()
    {
        //increment coin by +1
    }

    public void PotLeaf()
    {
        //decrease carSpeed for 2 secs
    }

    public void LapComplete()
    {
        //if the car crosses starting line, increment laps.
        //call addPoint()
    }

    public void speedBoost(int s) // pass in how many seconds the speed boost is applied for
    {
        // carSpeed is incremented for s seconds
    }

    public void addPoint()
    {
        points++;
    }

    public void StopSign()
    {
        //if player encounters stop sign, CarSpeed is reduced to 0 for 2 seconds at the crosswalk and all movement is disabled.
    }*/
}
