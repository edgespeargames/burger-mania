using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    Vector2 startPos;

    Vector2 targetPosition = new Vector2(-500, 200);
    float speed;

    Animator anim;

    float timeLeft = 10f;

    void OnEnable()
    {
        startPos = transform.position;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5f);
        transform.position = startPos;
        transform.parent.gameObject.SetActive(false);
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.speed = Random.Range(1,2);
        speed = Random.Range(0.05f, 0.15f);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }
}
