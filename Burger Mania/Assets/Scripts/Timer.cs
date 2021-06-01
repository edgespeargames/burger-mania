using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;

    [SerializeField] private Text timeText;

    void Start()
    {
        //Timer based on score which is based on meal complexity,
        //E.g. the higher the complexity the higher the score the more time needed

        time = GetComponentInParent<MealScore>().GetScore()*3; 
    }

    // Countdown constantly
    void Update()
    {
        timeText.text = Mathf.Round(time).ToString();

        // If time left is less than 3.5 change colour to red
        if (time < 3.5f)
            timeText.color = Color.red;

        time -= Time.deltaTime;

        // If time is less than 0 destroy the parent gameobject (the target burger)
        if (time < 0.0f)
            Destroy(transform.parent.gameObject);
    }

    // Destroy this game object (unused)
    public void DestroyTimer()
    {
        Destroy(this.gameObject);
    }

    // Return the current value of time
    public float GetTime()
    {
        return time;
    }

}
