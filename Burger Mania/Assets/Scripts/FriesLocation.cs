using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriesLocation : MonoBehaviour
{
    Vector2 newPosition;
    Vector2 offset;

    void Awake()
    {
        newPosition = new Vector2(this.transform.position.x + 1, this.transform.position.y);
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
