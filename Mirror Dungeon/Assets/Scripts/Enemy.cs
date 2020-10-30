using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth;
    public static int health;
    public AudioSource audio;
    public AudioClip hurt;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {

        health -= damage;
        audio.PlayOneShot(hurt);
        
        if (health < 1)
        {

            Debug.Log("dead");
            Destroy(gameObject);

        }

    }
}
