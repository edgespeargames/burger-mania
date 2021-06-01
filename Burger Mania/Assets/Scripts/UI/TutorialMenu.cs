using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialMenu : MonoBehaviour
{
    public GameObject readyUpMenu;

    public Text okText;
    public Text menuText;

    [SerializeField] private Button okButton;
    [SerializeField] private Button menuButton;

    [SerializeField] private GameObject fadeOutCanvas;

    private void OnEnable()
    {
        // Change text based on platform
#if UNITY_STANDALONE || UNITY_WEBGL
        okText.text = "OK! \n (Enter)";
        menuText.text = "Main Menu \n (Esc)";
#endif
    }

    void Start()
    {
        AudioManager.instance.Play("TutMusic");
        okButton.onClick.RemoveAllListeners();
        menuButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(OkButton_onClick); //subscribe to the onClick event
        menuButton.onClick.AddListener(MenuButton_onClick);
    }

    // Button Click Events below

    //Handle the onClick event
    public void OkButton_onClick()
    {
        OnPlayClicked();
    }

    //Handle the onClick event
    public void MenuButton_onClick()
    {
        OnMenuClicked();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnPlayClicked();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnMenuClicked();
        }
    }

    public void OnPlayClicked()
    {
        readyUpMenu.SetActive(true);

        gameObject.SetActive(false);
    }

    public void OnMenuClicked()
    {
        StartCoroutine(ReturnToMenu());
    }

    IEnumerator ReturnToMenu()
    {
        AudioManager.instance.FadeAll();

        fadeOutCanvas.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("MainMenu");
    }
}
