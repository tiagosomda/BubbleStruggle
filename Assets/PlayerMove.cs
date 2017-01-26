using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 4f;

    [HideInInspector]
    public float movement;

    private Rigidbody2D rb;

    public static bool moveLeft;
    public static bool moveRight;

    public bool isTouchEnabled;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
       if(isTouchEnabled)
        {
            movement = (moveLeft ? -1 : 0) + (moveRight ? 1 : 0);
        }

        rb.MovePosition(rb.position + new Vector2(movement * speed * Time.fixedDeltaTime, 0f));
    }
}
