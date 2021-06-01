using UnityEngine;

// Class to toggle the visibility of the Desktop/WebGL helper UI
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
