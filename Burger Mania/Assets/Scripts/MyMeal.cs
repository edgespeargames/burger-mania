using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control functionality for building a meal
// Includes keyboard control and button clicks
public class MyMeal : MonoBehaviour
{
    public static bool cheeseOn = false;
    public static bool tomatoOn = false;
    public static bool myFries = false;
    public static bool myDrink = false;
    public GameObject fries;
    public GameObject drink;

    #region ButtonMethods
    public void ButtonCheese()
    {
        ToggleCheese();
    }
    public void ButtonTomato()
    {
        ToggleTomato();
    }
    public void ButtonFries()
    {
        ToggleFries();
        fries.SetActive(myFries);
    }
    public void ButtonDrink()
    {
        ToggleDrink();
        drink.SetActive(myDrink);
    }
#endregion

    void Update()
    {
#if UNITY_STANDALONE || UNITY_WEBGL
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            ToggleTomato();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ToggleCheese();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ButtonFries();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ButtonDrink();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameSceneManager.Instance.MealMatch(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<PauseButton>().OnPauseClicked();
        }
#endif
    }

    public void ResetMeal()
    {
        cheeseOn = false;
        tomatoOn = false;
        myFries = false;
        myDrink = false;
        fries.SetActive(myFries);
        drink.SetActive(myDrink);
    }

    public static void ToggleCheese()
    {
        cheeseOn = !cheeseOn;
    }

    public static void ToggleTomato()
    {
        tomatoOn = !tomatoOn;
    }
    public static void ToggleFries()
    {
        myFries = !myFries;
    }

    public static void ToggleDrink()
    {
        myDrink = !myDrink;
    }
}
