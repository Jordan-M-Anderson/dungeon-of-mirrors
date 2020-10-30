using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{

    public GameObject myGameObj;
    public GameObject victory;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (myGameObj.GetComponent<Interactable>().canInteract)
            {

                victory.SetActive(true);
                Time.timeScale = 0f;

            }

        }
    }
}
