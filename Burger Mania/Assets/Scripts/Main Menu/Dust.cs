using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
