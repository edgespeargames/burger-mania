using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Displays the pause menu when clicking the button this script is attached to
public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    public void OnPauseClicked()
    {
        pauseCanvas.SetActive(true);
    }
}
