using System.Collections;
using UnityEngine;

// Destroy the gameobject half a second after it is enabled
public class Dust : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
