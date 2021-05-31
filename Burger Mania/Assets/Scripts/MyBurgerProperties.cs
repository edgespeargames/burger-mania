using UnityEngine;

// Class for the properties of the player's burger
// Could potentially be implemented as a sub class of an abstract class burgerproperties and as a sibling of burger properties.
public class MyBurgerProperties : MonoBehaviour
{
    public Burger Burger { get; set; }

    [SerializeField] private Sprite burgerSprite;
    [SerializeField] private Sprite cheeseSprite;
    [SerializeField] private Sprite tomatoSprite;
    [SerializeField] private Sprite cheeseTomatoSprite;


    void Update()
    {
        SetSprite();
    }

    // Set the game object's sprite based on its ingredients
    void SetSprite()
    {
        if (MyMeal.tomatoOn && MyMeal.cheeseOn)
            GetComponentInChildren<SpriteRenderer>().sprite = cheeseTomatoSprite;
        else if (MyMeal.tomatoOn)
            GetComponentInChildren<SpriteRenderer>().sprite = tomatoSprite;
        else if (MyMeal.cheeseOn)
            GetComponentInChildren<SpriteRenderer>().sprite = cheeseSprite;
        else
            GetComponentInChildren<SpriteRenderer>().sprite = burgerSprite;
    }

    // Returns a new Burger instance with the properties defined by its ingredients
    public Burger GetBurgerType()
    {
        Burger tempBurger = new Burger();
        tempBurger.Tomato = MyMeal.tomatoOn;
        tempBurger.Cheese = MyMeal.cheeseOn;
        return tempBurger;
    }
}
