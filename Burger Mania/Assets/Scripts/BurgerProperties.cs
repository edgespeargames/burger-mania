using UnityEngine;

public class BurgerProperties : MonoBehaviour
{
    public Burger Burger { get; set; }
    public Burger burger = new Burger();

    [SerializeField] private Sprite burgerSprite;
    [SerializeField] private Sprite cheeseSprite;
    [SerializeField] private Sprite tomatoSprite;
    [SerializeField] private Sprite cheeseTomatoSprite;

    private void Start()
    {
        SetSprite();
        SetScore();
    }

    private void SetScore()
    {
        if(burger.Tomato && burger.Cheese)
            GetComponent<MealScore>().AddToScore(4);
        else if(burger.Tomato || burger.Cheese)
            GetComponent<MealScore>().AddToScore(2);
        else
            GetComponent<MealScore>().AddToScore(1);
    }

    private void SetSprite()
    {
        if (burger.Tomato && burger.Cheese)
            GetComponentInChildren<SpriteRenderer>().sprite = cheeseTomatoSprite;
        else if (burger.Tomato)
            GetComponentInChildren<SpriteRenderer>().sprite = tomatoSprite;
        else if (burger.Cheese)
            GetComponentInChildren<SpriteRenderer>().sprite = cheeseSprite;
        else
            GetComponentInChildren<SpriteRenderer>().sprite = burgerSprite;
    }
}