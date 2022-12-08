using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    // public CanvasGroup GameOverScreenCanvasGroup;
    public Text ScoreText;
    public Text TimeText;
    public Text DamageGaugeText;
    public GameTimer GameTimer;

    public void Update()
    { 
        ShowScore(ScoreKeeper.GetScore()); 
        ShowDamageGuage(DamageGauge.GetDamage());
        ShowTime(GameTimer.GetTimeAsString());
    }

    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
        //CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }
    //
    // public void ShowGameOverScreen()
    // {
    //     CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    //     CanvasGroupDisplayer.Show(GameOverScreenCanvasGroup);
    // }
    //
    public void HideStartAndGameOverScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
        //CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }

    public void ShowScore(string score)
    {
        ScoreText.text = "Score: " + score;
    }

    public void ShowDamageGuage(string damage)
    {
        DamageGaugeText.text = "Hits: " + damage + "/10";
    }

    public void ShowTime(string time)
    {
        TimeText.text = "Time: " + time;
    }
}

