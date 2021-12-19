using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : Singleton<ShopMenu>
{
    public GameObject shopMenu;

    public Bullet bullet;
    public GunControl gun;

    public TMP_Text[] upgradeCosts;
    public TMP_Text healCost;
    public TMP_Text[] playerStats;


    void Start()
    {
        int i = 0;
        while (i < upgradeCosts.Length)
        {
            upgradeCosts[i].text = _UM.shopCosts[i].ToString();
            i++;
        }
        healCost.text = _UM.shopCosts[5].ToString();

        playerStats[0].text = _P.maxHealth.ToString();
        playerStats[1].text = _PC.moveSpeed.ToString();
        playerStats[2].text = bullet.damage.ToString();
        playerStats[3].text = gun.bulletSpeed.ToString();
        playerStats[4].text = gun.timeBetweenShots.ToString();
        playerStats[5].text = _P.currentHealth.ToString();
    }

    public void ToggleShop()
    {
        shopMenu.SetActive(!shopMenu.activeSelf);

        if (shopMenu.activeSelf)
        {
            _GM.gameState = GameState.Paused;
            Time.timeScale = 0f;
        }
        else
        {
            _GM.gameState = GameState.Playing;
            Time.timeScale = 1f;
            _GM.waveState = WaveState.ReadyToSpawn;
        }
    }
}
