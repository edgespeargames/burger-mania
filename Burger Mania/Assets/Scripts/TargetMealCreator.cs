using UnityEngine;

public class TargetMealCreator : MonoBehaviour
{
    [SerializeField] private GameObject targetFries;
    [SerializeField] private GameObject targetDrink;

    [SerializeField] private GameObject explosion;

    public bool isQuitting = false; // Variable to check if we're quitting the application

    [SerializeField] private GameObject timer; // Timer gameobject
    private GameObject localTimer; // Timer relevant to a specific game object when instantiated


    [SerializeField] private GameObject popUpText; // Score text that pops up upon match

    // Instantiate a timer and attach it to this instantiated targetburger gameobject
    private void Start()
    {
        localTimer = Instantiate(timer, transform.position, Quaternion.identity);
        localTimer.transform.parent = gameObject.transform;
    }

    // Instantiate fries and attach to this instantiated targetburger gameobject.
    // Add 2 to the potential score
    public void CreateFries()
    {
        GameObject fries = Instantiate(targetFries, transform.position, Quaternion.identity);
        fries.transform.parent = gameObject.transform;
        GetComponent<MealScore>().AddToScore(2);
    }

    // Instantiate drink and attach to this instantiated targetburger gameobject.
    // Add 2 to the potential score
    public void CreateDrink()
    {
        GameObject drink = Instantiate(targetDrink, transform.position, Quaternion.identity);
        drink.transform.parent = gameObject.transform;
        GetComponent<MealScore>().AddToScore(2);
    }

    // To prevent the issue with explosion animations being played on the home screen after quitting/leaving the game scene while still in play
    // Check to see if we are quitting
    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        // If we haven't quit the application (Moved to a different scene etc)
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
