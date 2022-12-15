using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public static class Game
{
    public static UI UI;
    public static GameTimer GameTimer;
    public static PlacePickupsAndObs PlacePickupsAndObs;
    private static bool isRunning = false;

    public static void Initialize(UI ui, GameTimer gameTimer)
    {
        UI = ui;
        GameTimer = gameTimer;
        UI.ShowStartScreen();
    }

    public static bool GameJustEnded()
    {
        if (!GameTimer.IsRunning() && isRunning)
        {
            //Debug.Log("game ended");
            return true;
        }
        return false;
    }

    public static void StartGame()
    {
        isRunning = true;
        UI.HideStartAndGameOverScreen();
        ScoreKeeper.Reset();
        DamageGauge.Replenish();
        GameParameters.Laps = 0;

        //change this for game time length
        GameTimer.StartTimer(120);
    }

    public static void EndGame()
    {
        isRunning = false;
        GameTimer.StopTimer();
        ScoreKeeper.AddToFinal(ScoreKeeper.GetScoreAsInt());
        ScoreKeeper.TakeFromFinal((10 - DamageGauge.GetDamageAsInt()));
        UI.ShowGameOverScreen();
    }

    public static bool IsRunning()
    {
        return isRunning;
    }
}