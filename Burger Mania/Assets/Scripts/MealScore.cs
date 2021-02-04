using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MealScore : MonoBehaviour
{
    private int mealScore;

    public void AddToScore(int num)
    {
        mealScore += num;
    }

    public void ResetScore()
    {
        mealScore = 0;
    }

    public int GetScore()
    {
        return mealScore;
    }
}
