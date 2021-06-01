// Basic score class for meals
using UnityEngine;
public class MealScore : MonoBehaviour
{
    private int mealScore; // The score of the meal

    // Increase score by num
    public void AddToScore(int num)
    {
        mealScore += num;
    }

    // Reset the score to 0
    public void ResetScore()
    {
        mealScore = 0;
    }

    // Return the value of mealScore
    public int GetScore()
    {
        return mealScore;
    }
}
