using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//game states used
public enum GameState
{
    Playing,
    Paused,
}


// states used to manage spawner and shop
public enum WaveState
{
    ReadyToSpawn,
    Spawned,
    Shop
}

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;
    public WaveState waveState;

    //variable used for player money
    public int money;


    //values used in wave spawner function
    public float waveTimer = 3f;
    public int enemyAmount = 9;
    public int waveCount = 0;
    public int totalEnemies;

    void Start()
    {
        Time.timeScale = 1f;
        //gamestates are set
        gameState = GameState.Playing;
        waveState = WaveState.ReadyToSpawn;
        //base money is set
        money = 0;
        //UI is updated
        _UI.UpdateMoney(money);
        _UI.UpdateWaveCount(waveCount);

    }
    void Update()
    {
        //ui updated
        _UI.UpdateTimer(waveTimer);
        _UI.UpdateHealth(_P.currentHealth);

        //checks if the game is in the correct state to spawn enemies
        if (waveState == WaveState.ReadyToSpawn)
        {
            if (_EM.enemies.Count == 0)
            {
                //timer countdown
                waveTimer -= Time.deltaTime;
                if (waveTimer <= 0)
                {
                    //timer is reset
                    waveTimer = 3;
                    //wavecount is incremented and ui updated
                    IncrementWaveCount();
                    _UI.UpdateWaveCount(waveCount);
                    //enemies are spawned and gamestate is changed
                    StartCoroutine(_EM.SpawnWithDelay());
                    waveState = WaveState.Spawned;
                }
                else if (waveTimer == 0 && _EM.enemies.Count == 0)
                    waveTimer = 3f;
            }
        }
        //checks if there are no enemies left so the shop can be opened
        else if (waveState == WaveState.Spawned && _EM.enemies.Count == 0)
        {
            //wavestate is changed and shop is turned on
            waveState = WaveState.Shop;
            _SM.ToggleShop();
        }
    }

    // original inputs used for upgrade system when UI wasnt working
    /*
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (money >= 70)
            {
                _UM.UpgradeHealth();
                money -= 70;
                _UI.UpdateMoney(money);
                Debug.Log("Upgrade bought!");
            }   
            else
                Debug.Log("Not enough money!");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (money >= 70)
            {
                _UM.UpgradeSpeed();
                money -= 70;
                _UI.UpdateMoney(money);
                Debug.Log("Upgrade bought!");
            }
            else
                Debug.Log("Not enough money!");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (money >= 70)
            {
                _UM.UpgradeDamage();
                money -= 70;
                _UI.UpdateMoney(money);
                Debug.Log("Upgrade bought!");
            }
            else
                Debug.Log("Not enough money!");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (money >= 70)
            {
                _UM.UpgradeBulletSpeed();
                money -= 70;
                _UI.UpdateMoney(money);
                Debug.Log("Upgrade bought!");
            } 
            else
                Debug.Log("Not enough money!");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (money >= 70)
            {
                _UM.UpgradeFireRate();
                money -= 70;
                _UI.UpdateMoney(money);
                Debug.Log("Upgrade bought!");
            }     
            else
                Debug.Log("Not enough money!");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (money >= 40)
            {
                _UM.Heal();
                money -= 40;
                _UI.UpdateMoney(money);
                Debug.Log("Health Restored!");
            }
            else
                Debug.Log("Not enough money!");
        }
    */
        

    //function that gets called to increase player money
    public void AddScore(int _money)
    {
        money += _money;
        _UI.UpdateMoney(money);
    }

    /*
     function used to increment the wave counter, and increase the amount of enemies that get spawned in the
     next wave */
    public void IncrementWaveCount()
    {
        waveCount += 1;
        totalEnemies = (enemyAmount + (waveCount * 2));
    }


}
