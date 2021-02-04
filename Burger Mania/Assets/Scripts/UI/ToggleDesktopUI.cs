using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDesktopUI : MonoBehaviour
{
    [SerializeField] private GameObject desktopUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            desktopUI.SetActive(!desktopUI.activeSelf);
            SaveSystem.SaveUI();
        }
            

    }
}
