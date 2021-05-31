using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMuteImage : MonoBehaviour
{
    [SerializeField] private Sprite muteOff; //mute off sprite
    [SerializeField] private Sprite muteOn; //mute on sprite

    //Toggle between the on and off sprites depending on whether muted
    public void OnToggleMute(bool mute)
    {
        if (mute)
            GetComponent<Image>().sprite = muteOn;
        else
            GetComponent<Image>().sprite = muteOff;
    }

}
