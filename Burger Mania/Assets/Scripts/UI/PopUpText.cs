using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Script to attach to popuptext prefab which will animate and then be destroyed
public class PopUpText : MonoBehaviour
{
    public Text text;
    public void SetText(string value, Color color)
    {
        text.text = value;
        text.color = color;
    }

    void Awake()
    {
        StartCoroutine(TimeOut());
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(this.gameObject);
    }
}
