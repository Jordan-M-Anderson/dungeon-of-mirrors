using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    public Transform Player;
    public Rigidbody2D rb2d;
    public float speed = 5f;
    Vector2 movement;
    float attackRange = 3;
    float directionLength;
    float attackRate = 3;
    float nextTimeToAttack = 0;


    void Start()
    {
		rb2d = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		// Find the position of the player relative to the enemy's position.
        Vector3 direction = (Player.position - transform.position);

        /** Rotate the enemy to face the player.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb2d.rotation = angle;
        */
        
        // Calculate the magnitude of direction.
        directionLength = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));

        // Attack the player if they are in range, and attack is off cooldown.
        if (directionLength <= attackRange && Time.time > nextTimeToAttack)
        {
            // Put attack on cooldown and attack.
            nextTimeToAttack = Time.time + attackRate;
            attack();
        }
        else
        {
            // Otherwise move the enemy towards the player.
            direction.Normalize();
            movement = direction;
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void attack()
    {
        // Swing sword
    }


}