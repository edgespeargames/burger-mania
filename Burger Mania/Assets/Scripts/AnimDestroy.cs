using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDestroy : MonoBehaviour
{
    public float delay = 0f;

    // Destroy the object 0 seconds after its animation finishes
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
