using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject confirmPanel;
    [SerializeField] private GameObject tutorialCanvas;

    [SerializeField] private GameObject fadeOutCanvas;

    [SerializeField] private Button okButton;
    [SerializeField] private Button menuButton;

    // When the pause menu is enabled, timescale is set to 0 for the game
    private void OnEnable()
    {
        Time.timeScale = 0;
        AudioManager.instance.Pause("GameMusic");
    }

    // Check if escape key is pressed to resume game (non-android only)
    void Update()
    {
#if UNITY_STANDALONE || UNITY_WEBGL
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnResumeClicked();
        }
#endif
    }

    // Below are button click methods

    public void OnTutorialClicked()
    {
        tutorialCanvas.SetActive(true);
        okButton.onClick.RemoveAllListeners();
        menuButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(OkButton_onClick); //subscribe to the onClick event
        menuButton.onClick.AddListener(MenuButton_onClick);
    }

    public void OnResumeClicked()
    {
        Time.timeScale = 1;
        AudioManager.instance.Resume("GameMusic");
        gameObject.SetActive(false);
    }

    public void OnQuitClicked()
    {
        confirmPanel.SetActive(true);
    }

    public void OnConfirmClicked()
    {
        Time.timeScale = 1;

        foreach (TargetMealCreator meal in FindObjectsOfType<TargetMealCreator>())
            meal.isQuitting = true;

        StartCoroutine(ReturnToMenu());
    }

    public void OnCancelClicked()
    {
        confirmPanel.SetActive(false);
    }

    //Handle the onClick event
    void OkButton_onClick()
    {
        tutorialCanvas.SetActive(false);
    }
    
    //Handle the onClick event
    void MenuButton_onClick()
    {
        tutorialCanvas.SetActive(false);
        OnQuitClicked();
    }

    IEnumerator ReturnToMenu()
    {
        AudioManager.instance.FadeAll();

        fadeOutCanvas.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("MainMenu");
    }
}
