using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb2d;
    public Animator animator;
    Vector2 movement;

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


}
