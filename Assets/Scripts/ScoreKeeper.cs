using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreKeeper
{
    private static int score = 0;
    private static int finalScore = 0;

    public static void Add(int amount)
    {
        score = score + amount;
    }

    public static string GetScore()
    {
        return score.ToString();
    }
    
    public static int GetScoreAsInt()
    {
        return score;
    }
    
    public static void AddToFinal(int amount)
    {
        finalScore = finalScore + amount;
    }
    
    public static void TakeFromFinal(int amount)
    {
        finalScore = finalScore - amount;
    }
    
    public static string GetFinalScore()
    {
        return finalScore.ToString();
    }
    
    public static int GetFinalScoreAsInt()
    {
        return finalScore;
    }
    
    public static void SetFinalScore(int amount)
    {
        finalScore = amount;
    }

    public static void Reset()
    {
        score = 0;
        finalScore = 0;
    }
}

