﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject mainBurger; //Player burger prefab
    [SerializeField] private GameObject targetBurger; //Target burger prefab

    private GameObject myBurger; //Instance of player burger prefab
    private Meal myMeal; //The meal the player has created
    [SerializeField] private List<Meal> targetMeals = new List<Meal>(); //List of meals the player has to match, Seriliazed for debug purposes
    private int maxMeals = 3; //Maximum number of meals

    [SerializeField] private Transform[] spawnPoints; //Target meal spawn points

    [SerializeField] private List<GameObject> mealObjects = new List<GameObject>(); //The actual instantiated meal objects in the scene

    [SerializeField] private GameObject gameOverMenu;

    #region Singleton
    private static GameSceneManager _instance;

    public static GameSceneManager Instance { get { return _instance; } }

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

    #region PrintMeals
    //Purely for debug purposes
    void PrintMeals(int i)
    {
        print("Fries: " + targetMeals[i].Fries +
            "Drink: " + targetMeals[i].Drink +
            "Burger Type: " + targetMeals[i].Burger.ToString());
    }
    #endregion

    void OnEnable()
    {
        StartCoroutine(Begin());
    }

    IEnumerator Begin()
    {
        myBurger = Instantiate(mainBurger, Vector2.zero, Quaternion.identity);
        for (int i = 3; i > 0; i--)
        {
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(CreateMeals());
        GlobalTimer.Instance.enabled = true;
    }

    //Iterate and create 3 new meals
    IEnumerator CreateMeals()
    {
        for (int i = 0; i < maxMeals; i++)
        {
            DisplayMeal(i);
            yield return new WaitForSeconds(0.3f);
        }
    }

    //Create a new Meal instance and add it to the list 'targetMeals'
    //Create a new target burger game object at the next available spawn point
    //Instantiate fries and/or drink objects if necessary
    //Add the new target game object to the list 'mealObjects'
    void DisplayMeal(int index)
    {
        GameObject tempBurger = Instantiate(targetBurger, spawnPoints[index].transform.position, Quaternion.identity);

        Meal tempTargetMeal = new Meal();
        targetMeals.Add(tempTargetMeal);

        targetMeals[index].GenerateMeal();
        if (targetMeals[index].Fries)
            tempBurger.GetComponent<TargetMealCreator>().CreateFries();
        if (targetMeals[index].Drink)
            tempBurger.GetComponent<TargetMealCreator>().CreateDrink();
        tempBurger.GetComponent<BurgerProperties>().burger = targetMeals[index].burger;
        mealObjects.Add(tempBurger);

        AudioManager.instance.Play("BurgerWoosh");
        //PrintMeals(index); // Debugging use only
    }

    //Instantiate the player's current custom meal and store in variable myMeal
    //Iterate over all meals in 'targetMeals' list
    //If there is a match then destroy the matching meal, call the method 'MealRotation'
    //Increment the player's score based on the value of the meal matched
    //Reset the player's custom burger to default
    public void MealMatch()
    {
        myMeal = new Meal 
        { 
            burger = myBurger.GetComponent<MyBurgerProperties>().GetBurgerType(),
            Fries = MyMeal.myFries,
            Drink = MyMeal.myDrink 
        }; //Object Initializer

        for (int i = 0; i < mealObjects.Count; i++)
        {
            if (myMeal.Equals(targetMeals[i]))
            {
                Destroy(mealObjects[i].gameObject);

                ScoreManager.Instance.ModifyScore(mealObjects[i].GetComponent<MealScore>().GetScore());
                AudioManager.instance.Play("Cash");
                MealRotation(i);

                GetComponent<MyMeal>().ResetMeal();
                return;
            }
        }
        AudioManager.instance.Play("Wrong"); //No match
    }

    //Called when a target burger's Timer runs out
    //Destroys the relevant target burger object and decrements the user's score
    //Runs the method 'MealRotation' before returning
    public void NotifyDestroyed(GameObject destroyedObject)
    {
        for (int i = 0; i < mealObjects.Count; i++)
        {
            if (mealObjects[i].gameObject == destroyedObject)
            {
                ScoreManager.Instance.ModifyScore(-mealObjects[i].GetComponent<MealScore>().GetScore());
                AudioManager.instance.Play("Whistle");
                MealRotation(i);
                
                return;
            }
        }
    }

    //Iterates through all of the target meal game objects to the right of the destroyed/matched meal
    //Calls MoveObject on them to move them to the spawn point to the left of where they are currently
    //Cleans up the destroyed list items that were destroyed
    //Runs 'DisplayMeal' to add and instantiate a new target meal at the last/right-most spawn point
    private void MealRotation(int index)
    {
        mealObjects.RemoveAt(index);

        for (int j = index; j < mealObjects.Count; j++)
        {
            StartCoroutine(MoveObject(mealObjects[j].gameObject,
                mealObjects[j].transform.position,
                spawnPoints[j].transform.position,
                0.3f));
        }
        targetMeals.RemoveAt(index);

        ScoreManager.Instance.UpdateScoreText();

        DisplayMeal(2);
    }

    //Movement animation coroutine for objects
    IEnumerator MoveObject(GameObject obj, Vector2 source, Vector2 target, float overTime)
    {
        float startTime = Time.time;

        while (obj != null && (Vector2)obj.transform.position != target)
        {
            obj.transform.position = Vector2.Lerp(source, target, ((Time.time - startTime) / overTime));
            yield return null;
        }
        transform.position = target;
    }

    void ResetScene()
    {
        Destroy(myBurger);
        GetComponent<MyMeal>().ResetMeal();
        foreach(GameObject meal in mealObjects)
        {
            Destroy(meal);
        }
        targetMeals.Clear();
        mealObjects.Clear();
    }

    public void EndShift()
    {
        ResetScene();
        GlobalTimer.Instance.ResetTimer();

        if (ScoreManager.Instance.GetTotalScore() > 0)
            AudioManager.instance.Play("Win");
        else
            AudioManager.instance.Play("Fail");
        
        gameOverMenu.SetActive(true);
        gameOverMenu.gameObject.GetComponent<GameOverMenu>().SetScore(ScoreManager.Instance.GetTotalScore());
        ScoreManager.Instance.ResetScore();
        gameObject.SetActive(false);
    }
}
