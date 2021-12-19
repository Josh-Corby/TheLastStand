using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameBehaviour
{
    public float maxHealth;
    private float health = 100;
    public float currentHealth;
    public float healthMultiplier;

    public int moneyWorth;
    public int totalWorth;

    private Rigidbody rb;
    public float moveSpeed;
    public float currentSpeed;
    public float speedMultiplier;

    public EnemyBullet enemyBullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    public PlayerController thePlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
        maxHealth = health * (_GM.waveCount * healthMultiplier);
        currentHealth = maxHealth;
        currentSpeed = moveSpeed + (_GM.waveCount * speedMultiplier);
        totalWorth = moneyWorth + _GM.waveCount;
    }

    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            shotCounter = timeBetweenShots;
            EnemyBullet newBullet = Instantiate(enemyBullet, firePoint.position, firePoint.rotation) as EnemyBullet;
            newBullet.speed = bulletSpeed;
            shotCounter = 1;
        }

        
    }

    void FixedUpdate()
    {
        rb.velocity = (transform.forward * currentSpeed);
    }

    public void HurtEnemy(int _Damage)
    {
        currentHealth -= _Damage;
        if (currentHealth <= 0)
        {
            Debug.Log("enemy died");
            _GM.AddScore(moneyWorth);
            _EM.DestroyEnemy(this.gameObject);
            
            
        }
    }
 

}
