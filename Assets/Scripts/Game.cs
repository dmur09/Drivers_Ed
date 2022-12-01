using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    //public static UI UI;
    public static GameTimer GameTimer;

    private static bool isRunning = false;

    public static void Initialize(UI ui, GameTimer gameTimer)
    {
        //UI = ui;
        GameTimer = gameTimer;
        //UI.ShowStartScreen();
    }

    public static bool GameJustEnded()
    {
        if (!GameTimer.IsRunning() && isRunning)
        {
            return true;
        }

        return false;
    }

    public static void StartGame()
    {
        isRunning = true;
        //UI.HideStartAndGameOverScreen();

        ScoreKeeper.Reset();
        
        //change this for game time length
        GameTimer.StartTimer(600);
    }

    public static void EndGame()
    {
        isRunning = false;
        GameTimer.StopTimer();
        //UI.ShowGameOverScreen();
    }

    public static bool IsRunning()
    {
        return isRunning;
    }
}