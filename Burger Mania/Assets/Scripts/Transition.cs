using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private Animation anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = this.gameObject.GetComponentInChildren<Animation>();
    }

    public void FlyIn()
    {
        anim.Play("fly_in");
    }
}
