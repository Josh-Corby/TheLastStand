using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : Singleton<PauseMenu>
{
    public GameObject pauseMenu;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }
    public void TogglePause()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (pauseMenu.activeSelf)
        {
            _MUI.TogglemainUI();
            _GM.gameState = GameState.Paused;
            Time.timeScale = 0f;
        }
        else
        {
            _MUI.TogglemainUI();
            _GM.gameState = GameState.Playing;
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        TogglePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        TogglePause();
        SceneManager.LoadScene("MainMenu");
    }
}
