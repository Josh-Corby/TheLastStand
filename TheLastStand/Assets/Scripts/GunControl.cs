using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : GameBehaviour
{

    public bool isFiring;

    //gun and bullet stats
    public Bullet bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    public AudioSource audioSource;
    public AudioClip fireSound;

    void Start()
    {
        //base bullet damage set at game start
        bullet.damage = 10;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //checks if gun is being fired and if the timer should countdown
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                //if the requirement is met a bullet is fired from the players firepoint
                Bullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Bullet;
                newBullet.speed = bulletSpeed;
                audioSource.PlayOneShot(fireSound);
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
