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

    void Update()
    {
        timeText.text = Mathf.Round(time).ToString();

        if (time < 3.5f)
            timeText.color = Color.red;

        time -= Time.deltaTime;

        if (time < 0.0f)
            Destroy(transform.parent.gameObject);
    }

    public void DestroyTimer()
    {
        Destroy(this.gameObject);
    }

    public float GetTime()
    {
        return time;
    }

}
