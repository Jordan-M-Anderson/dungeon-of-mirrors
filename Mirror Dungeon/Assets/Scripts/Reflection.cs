using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    public Transform player;
    public Transform attackPoint;
    public Rigidbody2D rb2d;
    public Animator animator;
    public LayerMask playerLayer;
    public float speed = 5f;
    Vector2 movement;
    float attackRange = 0.5f;
    float nextTimetoAttack = 0;
    float attackRate = 3;


    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Find the position of the player relative to the enemy's position.
        Vector3 direction = (player.position - transform.position);

        // If in range and attack is off cooldown, attack.
        if (direction.magnitude <= attackRange && nextTimetoAttack < Time.time)
        {
            attackPoint.transform.position = rb2d.position; //+ new Vector2(.005f, 0.5f);
            Attack();
            nextTimetoAttack = Time.time + attackRate;
        }
        else
        {
            // Otherwise move towards the player.
            direction.Normalize();
            movement = direction;
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Player>().Hurt();
        }
    }
}
