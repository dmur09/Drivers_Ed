using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreKeeper
{
    private static int score = 0;

    public static void Add(int amount)
    {
        score = score + amount;
    }

    public static string GetScore()
    {
        return score.ToString();
    }

    public static void Reset()
    {
        score = 0;
    }
}

