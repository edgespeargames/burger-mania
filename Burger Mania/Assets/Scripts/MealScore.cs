// Basic score class for meals
using UnityEngine;
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
