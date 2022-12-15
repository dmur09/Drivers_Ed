using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverScreenCanvasGroup;
    public Text ScoreText;
    public Text TimeText;
    public Text DamageGaugeText;
    public Text FinalScoreText;
    public GameTimer GameTimer;
    public Text Laps;

    public void Update()
    {
        ShowScore(ScoreKeeper.GetScore());
        ShowDamageGuage(DamageGauge.GetDamage());
        ShowTime(GameTimer.GetTimeAsString());
        ShowLaps();
    }

    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }
    
    public void ShowGameOverScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
        CanvasGroupDisplayer.Show(GameOverScreenCanvasGroup);
        ShowFinalScore(ScoreKeeper.GetFinalScore());
    }
    
    public void HideStartAndGameOverScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }

    public void ShowScore(string score)
    {
        ScoreText.text = "Score: " + score;
    }

    public void ShowDamageGuage(string damage)
    {
        DamageGaugeText.text = "Hits Remaining: " + damage;
    }

    public void ShowTime(string time)
    {
        TimeText.text = "Time: " + time;
    }
    
    public void ShowFinalScore(string finalScore)
    {
        FinalScoreText.text = "Final Score: " + finalScore;
    }

    public void ShowLaps()
    {
        Laps.text = "Lap: " + GameParameters.Laps;
    }
}

