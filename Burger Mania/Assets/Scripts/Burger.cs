using UnityEngine;

public class Burger : MonoBehaviour
{
    public bool Tomato { get; set; }
    public bool Cheese { get; set; }

    public void GenerateBurger()
    {
        int randNum = Random.Range(0, 2);
        Tomato = randNum > 0;

;       randNum = Random.Range(0, 2);
        Cheese = randNum > 0;
    }

    public override bool Equals(object obj)
    {
        Burger m = (Burger)obj;
        return (this.Tomato == m.Tomato) && (this.Cheese == m.Cheese);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
