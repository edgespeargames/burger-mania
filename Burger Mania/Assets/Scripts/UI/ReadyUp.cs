using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReadyUp : MonoBehaviour
{
    [SerializeField] private GameObject sceneManager;

    [SerializeField] private GameObject mainUI; // UI that is used across all platforms
    [SerializeField] private GameObject desktopUI; // UI that is used only for webgl and desktop

    [SerializeField] private Text playText;

    private void OnEnable()
    {
        // Change text on play button depending on platform
        playText.text = "Play!";
#if UNITY_STANDALONE || UNITY_WEBGL
        playText.text = "Play! \n (Enter)";
#endif

        mainUI.SetActive(true);
    }
    
    // Constantly check for enter key press to start game (if play button hasn't been clicked or tapped)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            OnPlayClicked();

#if UNITY_STANDALONE || UNITY_WEBGL
        desktopUI.SetActive(ToggleInfoUI.Instance.displayUI);
#endif

    }

    // Begin the countdown before starting the game when play is clicked
    public void OnPlayClicked()
    {
        sceneManager.SetActive(true);

        AudioManager.instance.Pause("TutMusic");
        AudioManager.instance.Play("GameMusic");

        StartCoroutine(Begin());
    }

    // Countdown from 3 to 1 inside play button
    IEnumerator Begin()
    {
        for (int i = 3; i > 0; i--)
        {
            playText.text = i.ToString();
            yield return new WaitForSeconds(0.5f);
        }
        gameObject.SetActive(false);
    }
}
