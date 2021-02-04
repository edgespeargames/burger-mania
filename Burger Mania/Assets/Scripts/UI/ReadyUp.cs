using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyUp : MonoBehaviour
{
    [SerializeField] private GameObject sceneManager;

    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject desktopUI;

    [SerializeField] private Text playText;

    private void OnEnable()
    {
        playText.text = "Play!";
#if UNITY_STANDALONE || UNITY_WEBGL
        playText.text = "Play! \n (Enter)";
#endif

        mainUI.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            OnPlayClicked();

#if UNITY_STANDALONE || UNITY_WEBGL
        desktopUI.SetActive(ToggleInfoUI.Instance.displayUI);
#endif

    }

    public void OnPlayClicked()
    {
        sceneManager.SetActive(true);

        AudioManager.instance.Pause("TutMusic");
        AudioManager.instance.Play("GameMusic");

        StartCoroutine(Begin());
    }

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
