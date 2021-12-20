using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            wavesSurvived.text = _GM.waveCount.ToString();
        }
    }
}
