using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Global score manager class (Singleton)
// Methods used within the GameSceneManager class
public class ScoreManager : MonoBehaviour
{
    private int totalScore = 0;
    [SerializeField] private Text scoreText;

    #region Singleton
    private static ScoreManager _instance;

    public static ScoreManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public void UpdateScoreText()
    {
        // If you fail to match a burger before time runs out, lose money
        if (totalScore < 0)
        {
            scoreText.text = "-$" + Mathf.Abs(totalScore).ToString();
            scoreText.color = Color.red;
        }
        // If you match a burger, gain money
        else if(totalScore > 0)
        {
            scoreText.text = "$" + totalScore.ToString();
            scoreText.color = Color.green;
        }
        // default
        else
        {
            scoreText.color = Color.black;
        }
            
    }

    // Add num to the total score
    public void ModifyScore(int num)
    {
        totalScore += num;
    }

    // Reset the total score to 0 and update UI
    public void ResetScore()
    {
        totalScore = 0;
        scoreText.text = "0";
        scoreText.color = Color.black;
    }

    // Return the total score
    public int GetTotalScore()
    {
        return totalScore;
    }
}
