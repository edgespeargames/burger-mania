using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInfoUI : MonoBehaviour
{
    [SerializeField] private GameObject desktopUI;

    public bool displayUI;

    #region Singleton
    private static ToggleInfoUI _instance;

    public static ToggleInfoUI Instance { get { return _instance; } }

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

    void Start()
    {
#if !UNITY_STANDALONE && !UNITY_WEBGL
        gameObject.SetActive(false);
#endif
        SaveSystem.LoadUI();
    }

    private void Update()
    {
#if UNITY_STANDALONE || UNITY_WEBGL
        transform.GetChild(0).gameObject.SetActive(desktopUI.activeSelf);
#endif
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            displayUI = !displayUI;
            SaveSystem.SaveUI();
        }
    }
}
