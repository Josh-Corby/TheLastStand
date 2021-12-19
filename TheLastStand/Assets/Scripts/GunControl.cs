using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : GameBehaviour
{
    public bool isFiring;

    public Bullet bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    void Start()
    {
        
    }

    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Bullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Bullet;
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
