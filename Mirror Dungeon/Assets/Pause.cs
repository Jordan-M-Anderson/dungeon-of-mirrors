using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool gamePaused = false;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject mainPauseScreen;
    [SerializeField] GameObject optionsPauseScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        mainPauseScreen.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        optionsPauseScreen.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void LoadMenu() 
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        gamePaused = false;
    }
}
