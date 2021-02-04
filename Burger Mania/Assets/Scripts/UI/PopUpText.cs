using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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
