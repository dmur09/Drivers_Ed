using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonoWrapper : MonoBehaviour
{
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
            MiniMap.SetActive(false);
            Sounds.PlayGameOver();
        }
    }

    public void StartGame()
    {
        Game.StartGame();
        MiniMap.SetActive(true);
        Sounds.StopStartSound();
    }
}
