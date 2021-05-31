using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static List<PlayerScore> highScoreList = new List<PlayerScore>(); // List of PlayerScore instances

    public GameObject leftPanel;
    public GameObject rightPanel;
    public Text textPrefab;

    // Creates a new PlayerScore instance with the newly entered name and score
    // Adds it to the highsScoreList
    public static void AddScore(string newName, int newScore)
    {
        PlayerScore newPlayerScore = new PlayerScore
        {
            name = newName,
            finalScore = newScore
        };
        highScoreList.Add(newPlayerScore);
    }

    // Clears the highScoreList
    public static void ClearList()
    {
        highScoreList.Clear();
    }

    // Returns the highScoreList of PlayerScore objects
    public static List<PlayerScore> GetList()
    {
        return highScoreList;
    }

    // Remove text (highscores)
    private void ClearObjects(GameObject panel)
    {
        foreach (Transform text in panel.transform)
        {
            Destroy(text.gameObject);
        }
    }

    // Remove text from both panels
    public void ClearPanels()
    {
        ClearObjects(leftPanel);
        ClearObjects(rightPanel);
    }

    // Clear both panels, 
    // Sort the scores from high to low
    // Instantiate text objects and assign them the values from the PlayerScore instances in the highScoreList
    public void ShowHighScores()
    {
        ClearPanels();

        highScoreList.Sort();
        highScoreList.Reverse();

        for(int i = 0; i < 5; i++)
        {
            Text tempText = Instantiate(textPrefab);
            tempText.transform.SetParent(leftPanel.transform);
            tempText.transform.localScale = new Vector3(1, 1, 1);
            if (i < highScoreList.Count)
                tempText.text = highScoreList[i].name;
            else
                tempText.text = "AAA";

            Text tempScoreText = Instantiate(textPrefab);
            tempScoreText.transform.SetParent(rightPanel.transform);
            tempScoreText.transform.localScale = new Vector3(1, 1, 1);
            if (i < highScoreList.Count)
                tempScoreText.text = highScoreList[i].finalScore.ToString();
            else
                tempScoreText.text = "0";
        }
    }

}
