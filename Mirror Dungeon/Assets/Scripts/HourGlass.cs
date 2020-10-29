using UnityEngine.SceneManagement;
using UnityEngine;

public class HourGlass : MonoBehaviour
{
    public GameObject myGameObj;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (myGameObj.GetComponent<Interactable>().canInteract)
            {

                SceneManager.LoadScene("Sand");

            }

        }
    }
}
