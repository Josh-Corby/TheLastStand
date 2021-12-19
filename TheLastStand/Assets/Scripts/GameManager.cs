using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState
{
    Start,
    Playing,
    Paused,
    GameOver
}

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;
    public int money;

    public float waveTimer = 3f;
    public int enemyAmount = 9;
    public int waveCount = 0;
    public int totalEnemies;

    void Start()
    {
        gameState = GameState.Playing;
        money = 1000;
        _UI.UpdateMoney(money);
        _UI.UpdateWaveCount(waveCount);

    }
    void Update()
    { 
        _UI.UpdateTimer(waveTimer);
        _UI.UpdateHealth(_P.currentHealth);

        if (_EM.enemies.Count == 0)
        {
            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0)
            {
                waveTimer = 3;
                IncrementWaveCount();
                _UI.UpdateWaveCount(waveCount);
                StartCoroutine(_EM.SpawnWithDelay());
                
            }
            else if (waveTimer == 0 && _EM.enemies.Count == 0)
                waveTimer = 3f;
        }

        if(Input.GetKeyDown(KeyCode.Z))
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
    }


    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
    }
    public void AddScore(int _money)
    {
        money += _money;
        _UI.UpdateMoney(money);
    }


    public void IncrementWaveCount()
    {
        waveCount += 1;
        totalEnemies = (enemyAmount + waveCount);
    }
}
