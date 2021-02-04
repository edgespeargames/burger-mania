using UnityEngine;

public class Meal : MonoBehaviour
{
    public Burger Burger { get; set; }
    public bool Fries { get; set; }
    public bool Drink { get; set; }

    public Burger burger = new Burger();


    public void GenerateMeal()
    {
        int randNum = Random.Range(0, 2);
        Fries = randNum > 0;
        randNum = Random.Range(0, 2);
        Drink = randNum > 0;
        
        burger.GenerateBurger();
    }

    public override bool Equals(object obj)
    {
        Meal m = (Meal)obj;
        return (this.burger.Equals(m.burger)) && (this.Fries == m.Fries) && (this.Drink == m.Drink);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
