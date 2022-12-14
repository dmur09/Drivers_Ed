using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonoWrapper : MonoBehaviour
{
    public Car Car;
    public UI UI;
    public GameObject MiniMap;
    public GameTimer GameTimer;
    public Sounds Sounds;


    void Start()
    {
        Game.Initialize(UI, GameTimer);
        MiniMap.SetActive(false);
        Sounds.PlayStart();
    }
    
    void Update()
    {
        if (Game.GameJustEnded() || DamageGauge.damage <= 0)
        {
            Game.EndGame();
            Car.ResetRotation();
            MiniMap.SetActive(false);
            Sounds.PlayGameOver();
            ScoreKeeper.Reset();
        }
    }

    public void StartGame()
    {
        Car.SetRotation();
        Game.StartGame();
        MiniMap.SetActive(true);
        Sounds.StopStartSound();
    }
}
