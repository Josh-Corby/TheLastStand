using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    //UI Elements
    public TMP_Text moneyText;
    public TMP_Text healthText;
    public TMP_Text waveTimer;
    public TMP_Text waveCount;
    //public Image HealthBar;

    //function used to update the player money in the ui
    private void Start()
    {
    }
    public void UpdateMoney(int _money)
    {
        moneyText.text = "Money: " + _money.ToString();
    }

    public void UpdateHealth(float _health)
    {
        healthText.text = "Health: " + _health.ToString();
        healthText.color = _health < 10 ? Color.red : Color.black;
       // HealthBar.fillAmount = _P.currentHealth / _P.startingHealth;
    }

    //fuction used to update the wave counter in the ui
    public void UpdateWaveCount(int _wave)
    {
        waveCount.text = "Wave: " + _GM.waveCount.ToString();
    }

    //function used to update the timer in the ui
    public void UpdateTimer(float _time)
    {
        waveTimer.text = _GM.waveTimer.ToString("F2");
    }


}
