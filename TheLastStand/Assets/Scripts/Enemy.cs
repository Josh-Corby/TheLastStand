using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameBehaviour
{

    //Enemy stats
    [Header("Enemy Stats")]
    public float maxHealth;
    private float health = 50;
    public float currentHealth;
    public float healthMultiplier;
    public int moneyWorth;
    public int totalWorth;
    public float moveSpeed;
    public float currentSpeed;
    public float speedMultiplier;

    private Rigidbody rb;

    //reference to bullet and bullet stats
    public EnemyBullet enemyBullet;
    public Transform firePoint;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;

    
    public PlayerController thePlayer;

    //enemy stats are constantly increasing as waves increase
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
        maxHealth = health * (_GM.waveCount * healthMultiplier);
        currentHealth = maxHealth;
        currentSpeed = moveSpeed + (_GM.waveCount * speedMultiplier);
        totalWorth = moneyWorth + (_GM.waveCount * 2);
    }

    
    void Update()
    {
        //The enemy constantly looks at the player
        transform.LookAt(thePlayer.transform.position);
        shotCounter -= Time.deltaTime;
        // enemy fires a projectile when counter reaches 0
        if (shotCounter <= 0)
        {
            shotCounter = timeBetweenShots;
            EnemyBullet newBullet = Instantiate(enemyBullet, firePoint.position, firePoint.rotation) as EnemyBullet;
            newBullet.speed = bulletSpeed;
            shotCounter = 1;
        }

        
    }

    //enemy movespeed calculation
    void FixedUpdate()
    {
        rb.velocity = (transform.forward * currentSpeed);
    }

    //function for how enemies take damage and die when their health reaches 0
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
