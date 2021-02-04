using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (totalScore < 0)
        {
            scoreText.text = "-$" + Mathf.Abs(totalScore).ToString();
            scoreText.color = Color.red;
        }
        else if(totalScore > 0)
        {
            scoreText.text = "$" + totalScore.ToString();
            scoreText.color = Color.green;
        }
        else
        {
            scoreText.color = Color.black;
        }
            
    }

    public void ModifyScore(int num)
    {
        totalScore += num;
    }

    public void ResetScore()
    {
        totalScore = 0;
        scoreText.text = "0";
        scoreText.color = Color.black;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }
}
