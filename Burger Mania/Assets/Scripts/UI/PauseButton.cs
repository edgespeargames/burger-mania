using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    public void OnPauseClicked()
    {
        pauseCanvas.SetActive(true);
    }
}
