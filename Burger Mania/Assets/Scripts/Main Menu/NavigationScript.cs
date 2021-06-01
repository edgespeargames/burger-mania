using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Navigation Manager Script to manage scene transitions and high score display
public class NavigationScript : MonoBehaviour
{
    [SerializeField] private GameObject highScoreCanvas;
    [SerializeField] private GameObject creditsCanvas;
    [SerializeField] private GameObject fadeOutCanvas;

    [SerializeField] private GameObject highScore;


    public void OnPlayClicked()
    {
        StartCoroutine(PlayGame());
    }

    IEnumerator PlayGame()
    {
        AudioManager.instance.FadeOut("MenuMusic");

        AudioManager.instance.Play("DoorOpening");

        fadeOutCanvas.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("GameScene");
    }

    public void OnHighScoreClicked()
    {
        SaveSystem.LoadHighScores();
        highScore.GetComponent<HighScore>().ShowHighScores();
        highScoreCanvas.SetActive(true);
    }

    public void HighScoreClose()
    {
        highScoreCanvas.SetActive(false);
    }

    public void OnCreditsClicked()
    {
        creditsCanvas.SetActive(!creditsCanvas.activeSelf);
    }
}
