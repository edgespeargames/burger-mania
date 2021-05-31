using UnityEngine;

public class Transition : MonoBehaviour
{
    private Animation anim;

    void Awake()
    {
        anim = this.gameObject.GetComponentInChildren<Animation>();
    }

    // Play the fly_in animation
    public void FlyIn()
    {
        anim.Play("fly_in");
    }
}
