using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    #region Singleton
    private static GlobalTimer _instance;

    public static GlobalTimer Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    private float timeLimit = 20f;

    [SerializeField] private Text timerText;

    void OnEnable()
    {
        timerText.text = timeLimit.ToString();
        timerText.color = Color.black;
        StartCoroutine(Countdown());
    }

    public void ResetTimer()
    {
        StopAllCoroutines();
        timerText.text = timeLimit.ToString();
        timerText.color = Color.black;
        enabled = false;
    }

    IEnumerator Countdown()
    {
        for(float i = timeLimit; i > 4; i--)
        {
            timerText.text = Mathf.RoundToInt(i).ToString();
            yield return new WaitForSeconds(1f);
        }
        AudioManager.instance.Play("AlarmTick");
        timerText.color = Color.red;
        for(float i = 4; i > 0; i--)
        {
            timerText.text = Mathf.RoundToInt(i).ToString();
            yield return new WaitForSeconds(1f);
        }
        AudioManager.instance.Stop("AlarmTick");
        AudioManager.instance.PlayOnce("Finish");
        GameSceneManager.Instance.EndShift();
    }
}
