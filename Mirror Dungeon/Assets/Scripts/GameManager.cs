using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject gameOver;

    public void EndGame() {
        gameHasEnded = true;
        if (gameHasEnded)
        {
            Player.health = 2;
            RestartMenu();
        }

    }

    public void loadMenu()
    {
        Time.timeScale = 1;
        Player.health = 2;
        SceneManager.LoadScene("Menu");

    }

    void RestartMenu()
    {

        gameOver.SetActive(true);
        //Player UI setActive(false)

    }
}
