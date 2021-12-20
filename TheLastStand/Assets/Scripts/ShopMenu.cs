using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : Singleton<ShopMenu>
{
    public GameObject shopMenuCanvas;

    public Bullet bullet;
    public GunControl gun;

    //text array of how much the upgrades cost to be displayed in the chop
    public TMP_Text[] upgradeCosts;
    
    //text array of what the players current stats are to be displayed in the shop
    public TMP_Text[] playerStats;

    public TMP_Text multiShotCost;
    public TMP_Text healCost;


    void Start()
    {
        int i = 0;
        //sets the text of the upgrade costs to their respective values
        while (i < upgradeCosts.Length)
        {
            upgradeCosts[i].text = _UM.shopCosts[i].ToString();
            i++;
        }
        healCost.text = _UM.shopCosts[5].ToString();
        multiShotCost.text = _UM.shopCosts[6].ToString();

        //player stats are set to their respective values when the shop is turned on
        playerStats[0].text = _P.maxHealth.ToString();
        playerStats[1].text = _PC.moveSpeed.ToString();
        playerStats[2].text = bullet.damage.ToString();
        playerStats[3].text = gun.bulletSpeed.ToString();
        playerStats[4].text = gun.timeBetweenShots.ToString();
        playerStats[5].text = _P.currentHealth.ToString();
        
    }

    //function used to toggle the shop from on and off
    public void ToggleShop()
    {
        shopMenuCanvas.SetActive(!shopMenuCanvas.activeSelf);

        if (shopMenuCanvas.activeSelf)
        {
            //when shop is activated the main UI is disabled, the gamestate is changed and time is paused.
            _MUI.TogglemainUI();
            _GM.gameState = GameState.Paused;
            Time.timeScale = 0f;
        }
        else
        {
            /*when the shop is disabled the gamestate is changed, wavestate is changed, and time is resumed
            main UI is turned back on */
            _MUI.TogglemainUI();
            _GM.gameState = GameState.Playing;
            Time.timeScale = 1f;
            _GM.waveState = WaveState.ReadyToSpawn;
        }
    }
}
