﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb2d;
    public Animator animator;
    Vector2 movement;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public static int health = 2;
    public bool blocking = false;
    public float blockTime;
    private float timeBlocked;

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (!blocking) {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {

                attackPoint.transform.position = rb2d.position + new Vector2(.005f, 0.5f);

            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {

                attackPoint.transform.position = rb2d.position + new Vector2(.5f, 0.005f);

            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {

                attackPoint.transform.position = rb2d.position + new Vector2(-.5f, 0.005f);

            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {

                attackPoint.transform.position = rb2d.position + new Vector2(.005f, -0.5f);

            }


            if (Input.GetKeyDown(KeyCode.Space)) {

                Attack();

            } else if (Input.GetKeyDown(KeyCode.LeftShift)) {

                Block();

            }
        }

        if (timeBlocked < Time.time)
        {

            blocking = false;
            speed = 2.5f;
            animator.SetBool("Blocking", false);

        }
    }

    void Attack() {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        animator.SetTrigger("Attack");

        foreach (Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().takeDamage(1);
        }
    }

    public void Hurt() {

        if (!blocking)
        {
            health--;
        }

        if (health < 1)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;

        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Block()
    {
        speed = 0;
        blocking = true;
        timeBlocked = Time.time + blockTime;
        animator.SetBool("Blocking", true);

    }

}
