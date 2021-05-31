using UnityEngine;

public class Meal
{
    public Burger Burger { get; set; } 
    public bool Fries { get; set; }
    public bool Drink { get; set; }

    public Burger burger = new Burger(); //instantiate a new Burger

    //Set the fries and drinks with a random number 0 - 1,
    //run the GenerateBurger method on the instantiated burger
    public void GenerateMeal()
    {
        int randNum = Random.Range(0, 2);
        Fries = randNum > 0;
        randNum = Random.Range(0, 2);
        Drink = randNum > 0;
        
        burger.GenerateBurger();
    }

    //Override the Equals method to check for equality between two Meal objects
    public override bool Equals(object obj)
    {
        Meal m = (Meal)obj;
        return (this.burger.Equals(m.burger)) && (this.Fries == m.Fries) && (this.Drink == m.Drink);
    }

    //If you override the GetHashCode method, you should also override Equals, and vice versa. 
    //If your overridden Equals method returns true when two objects are tested for equality, your overridden GetHashCode method must return the same value for the two objects. -MS Docs
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
