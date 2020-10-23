using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public float lifeSpan;

    private void Start()
    {
        lifeSpan += Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time  > lifeSpan) {

            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {

            Player.health--;
            if (Player.health < 1) {
                Debug.Log("Game Over");

            }
        }

        if (collision.gameObject.layer != 8) {

            Destroy(gameObject);

        }
    }
}
