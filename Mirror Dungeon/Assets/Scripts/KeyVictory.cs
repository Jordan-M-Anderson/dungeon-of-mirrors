using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyVictory : MonoBehaviour
{
    public bool hasKilled;
    public GameObject key;
    public int enemeyCount;
    public int enemiesSlain;

    void Start()
    {
        enemiesSlain = 0;
    }

    public void killEnemey() {

        enemiesSlain++;
        if (enemiesSlain >= enemeyCount) {

            key.SetActive(true);

        }

    }
}
