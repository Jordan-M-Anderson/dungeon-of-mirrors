using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++) {

            if (i == popUpIndex)
            {

                popUps[popUpIndex].SetActive(true);

            }
            else {

                popUps[popUpIndex].SetActive(false);

            }

        }

        if (popUpIndex == 0) {

            switch (popUpIndex){

                //Left, right, up, down
                case 0:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
                    {

                        popUpIndex++;

                    }
                break;
                
                //Attack
                case 1:
                    if (Input.GetKeyDown(KeyCode.Space))
                    {

                        popUpIndex++;

                    }
                 break;
                
                //Sheild
                case 2:
                    if (Input.GetKeyDown(KeyCode.LeftShift))
                    {

                        popUpIndex++;

                    }
                 break;

            }

        }
    }
}
