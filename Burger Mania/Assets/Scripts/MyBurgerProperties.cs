using UnityEngine;

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

    public Burger GetBurgerType()
    {
        Burger tempBurger = new Burger();
        tempBurger.Tomato = MyMeal.tomatoOn;
        tempBurger.Cheese = MyMeal.cheeseOn;
        return tempBurger;
    }
}
