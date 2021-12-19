using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : Singleton<PauseMenu>
{
    public GameObject ui;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Toggle();
    }
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            _GM.gameState = GameState.Paused;
            Time.timeScale = 0f;
        }
        else
        {
            _GM.gameState = GameState.Playing;
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Toggle();
        SceneManager.LoadScene("MainMenu");
    }
}
