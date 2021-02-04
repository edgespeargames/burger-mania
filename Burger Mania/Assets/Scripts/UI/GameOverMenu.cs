using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject readyUpCanvas;
    [SerializeField] GameObject fadeOutCanvas;

    [SerializeField] GameObject UICanvas;
    [SerializeField] GameObject desktopUICanvas;

    private int totalScore;

    [SerializeField] Text scoreText;

    [SerializeField] InputField nameText;

    void OnEnable()
    {
        AudioManager.instance.Stop("GameMusic");
        AudioManager.instance.Play("TutMusic");
        UICanvas.SetActive(false);

#if UNITY_STANDALONE || UNITY_WEBGL
        desktopUICanvas.SetActive(false);
#endif
    }

    public void SetScore(int score)
    {
        totalScore = Mathf.Abs(score);

        scoreText.text = "$" + totalScore.ToString();

        if (score < 0)
        {
            scoreText.text = "-" + scoreText.text;
            scoreText.color = Color.red;
            
            return;
        }

        scoreText.color = Color.green;
    }

    void AddHighScore()
    {
        if(nameText.text != "" && totalScore != 0)
            HighScore.AddScore(nameText.text, totalScore);
    }

    public void OnReplayClick()
    {
        AddHighScore();
        readyUpCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnMenuClicked()
    {
        AddHighScore();
        StartCoroutine(ReturnToMenu());
    }

    IEnumerator ReturnToMenu()
    {
        AudioManager.instance.FadeOut("TutMusic");

        fadeOutCanvas.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("MainMenu");
    }
}
