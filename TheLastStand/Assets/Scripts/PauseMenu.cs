using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : Singleton<PauseMenu>
{
    public GameObject pauseMenuCanvas;


    void Update()
    {
        //input to pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }
    //function to pause the game
    public void TogglePause()
    {
        pauseMenuCanvas.SetActive(!pauseMenuCanvas.activeSelf);

        if (pauseMenuCanvas.activeSelf)
        {
            //when the game is paused the main UI is disabled and time is paused
            _MUI.TogglemainUI();
            _GM.gameState = GameState.Paused;
            Time.timeScale = 0f;
        }
        else
        {
            //when the game is resumed the main UI is enabled and time is resumed
            _MUI.TogglemainUI();
            _GM.gameState = GameState.Playing;
            Time.timeScale = 1f;
        }
    }

    //reloads game scene
    public void Retry()
    {
        TogglePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //loads main menu scene
    public void Menu()
    {
        TogglePause();
        SceneManager.LoadScene("MainMenu");
    }
}
