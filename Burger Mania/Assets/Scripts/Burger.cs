using UnityEngine;

public class Burger
{
    public bool Tomato { get; set; }
    public bool Cheese { get; set; }

    // Generate a random burger based on random number 0 or 1
    // Does not instantiate a burger
    public void GenerateBurger()
    {
        int randNum = Random.Range(0, 2);
        Tomato = randNum > 0;

;       randNum = Random.Range(0, 2);
        Cheese = randNum > 0;
    }

    // Override the Equals method to compare two burgers
    public override bool Equals(object obj)
    {
        Burger m = (Burger)obj;
        return (this.Tomato == m.Tomato) && (this.Cheese == m.Cheese);
    }

    //If you override the GetHashCode method, you should also override Equals, and vice versa. 
    //If your overridden Equals method returns true when two objects are tested for equality, your overridden GetHashCode method must return the same value for the two objects. -MS Docs
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
