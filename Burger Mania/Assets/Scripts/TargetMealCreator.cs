using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMealCreator : MonoBehaviour
{
    [SerializeField] private GameObject targetFries;
    [SerializeField] private GameObject targetDrink;

    [SerializeField] private GameObject explosion;

    public bool isQuitting = false;

    [SerializeField] private GameObject timer;
    private GameObject localTimer;


    [SerializeField] private GameObject popUpText;

    public int iD;

    private void Start()
    {
        localTimer = Instantiate(timer, transform.position, Quaternion.identity);
        localTimer.transform.parent = gameObject.transform;
    }

    public void CreateFries()
    {
        GameObject fries = Instantiate(targetFries, transform.position, Quaternion.identity);
        fries.transform.parent = gameObject.transform;
        GetComponent<MealScore>().AddToScore(2);
    }

    public void CreateDrink()
    {
        GameObject drink = Instantiate(targetDrink, transform.position, Quaternion.identity);
        drink.transform.parent = gameObject.transform;
        GetComponent<MealScore>().AddToScore(2);
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            var popUp = Instantiate(popUpText, transform.position, Quaternion.identity);

            if(GetComponentInChildren<Timer>().GetTime() < 0)
            {
                popUp.GetComponent<PopUpText>().SetText
                    ("-$" + GetComponent<MealScore>().GetScore().ToString(),
                    Color.red);
                GameSceneManager.Instance.NotifyDestroyed(this.gameObject);
            }
            else
            {
                popUp.GetComponent<PopUpText>().SetText
                    ("$" + GetComponent<MealScore>().GetScore().ToString(),
                    Color.green);
            }
                
        }
            
    }

}
