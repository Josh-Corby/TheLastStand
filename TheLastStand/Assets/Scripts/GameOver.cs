using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : Singleton<GameOver>
{

    public GameObject gameOverCanvas;
    public TMP_Text wavesSurvived;
    public void ToggleGameOver()
    {
        gameOverCanvas.SetActive(true);

        if (gameOverCanvas.activeSelf)
        {
            Time.timeScale = 0f;
            wavesSurvived.text = "Waves survived: " +  _GM.waveCount.ToString();
        }
    }
    public void Retry()
    {
        ToggleGameOver();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        ToggleGameOver();
        SceneManager.LoadScene("MainMenu");
    }
}
