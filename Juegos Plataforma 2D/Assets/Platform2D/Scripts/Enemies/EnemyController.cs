using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 1f;
    public float speed = 1f;


    Rigidbody2D rb2D;
    
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2D.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2D.velocity.x, -maxSpeed, maxSpeed);
        rb2D.velocity = new Vector2(limitedSpeed, rb2D.velocity.y);

        if (rb2D.velocity.x > -.01f && rb2D.velocity.x < .01f)
        {
            speed = -speed;
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
        }

        if (speed < 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (speed > 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

    }
}
