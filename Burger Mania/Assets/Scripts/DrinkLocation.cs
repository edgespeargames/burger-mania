using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkLocation : MonoBehaviour
{
    Vector2 newPosition;
    void Awake()
    {
        newPosition = new Vector2(this.transform.position.x - 1, this.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {

        this.transform.position = Vector2.Lerp(this.transform.position, newPosition, 0.05f);
    }
}
