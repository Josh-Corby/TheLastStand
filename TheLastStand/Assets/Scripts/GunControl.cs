using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : Singleton<GunControl>
{

    public bool isFiring;

    //gun and bullet stats
    public Bullet bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;

    public bool multishot;

    public AudioSource audioSource;
    public AudioClip fireSound;

    void Start()
    {
        //base bullet damage set at game start
        bullet.damage = 10;
        multishot = false;
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
                if(multishot == false)
                {
                    shotCounter = timeBetweenShots;
                    //if the requirement is met a bullet is fired from the players firepoint
                    Bullet newBullet = Instantiate(bullet, firePoint1.position, firePoint1.rotation) as Bullet;
                    newBullet.speed = bulletSpeed;
                    audioSource.PlayOneShot(fireSound);
                }
                if(multishot == true)
                {
                    shotCounter = timeBetweenShots;
                    //if the requirement is met a bullet is fired from the players firepoint
                    Bullet newBullet1 = Instantiate(bullet, firePoint1.position, firePoint1.rotation) as Bullet;
                    Bullet newBullet2 = Instantiate(bullet, firePoint2.position, firePoint2.rotation) as Bullet;
                    Bullet newBullet3 = Instantiate(bullet, firePoint3.position, firePoint3.rotation) as Bullet;
                    newBullet1.speed = bulletSpeed;
                    newBullet2.speed = bulletSpeed;
                    newBullet3.speed = bulletSpeed;
                    audioSource.PlayOneShot(fireSound);
                }
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
