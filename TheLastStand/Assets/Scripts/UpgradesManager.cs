using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : Singleton<UpgradesManager>
{
    public Bullet bullet;
    public GunControl gun;

    public int[] shopCosts;
    /* 
    0 upgrade health
    1 upgrade speed
    2 upgrade damage
    3 upgrade bullet speed
    4 upgrade bullet damage
    5 upgrade fire rate
    6 heal
     */

    private void Start()
    {


    }
    public void UpgradeHealth()
    {
        if (_GM.money >= shopCosts[0])
        {
            _P.maxHealth += 10;
            shopCosts[0] += 5;
        }    
    }

    public void UpgradeSpeed()
    {
        if (_GM.money >= shopCosts[1])
        { 
            _PC.moveSpeed += 0.5f;
            shopCosts[1]+= 5;
        }
    }

    public void UpgradeDamage()
    {

        if(_GM.money >= shopCosts[2])
        {
            bullet.damage += 2;
            shopCosts[2] += 5;
        }
    }

    public void UpgradeBulletSpeed()
    {
        if(_GM.money >= shopCosts[3])
        {
            gun.bulletSpeed += 0.5f;
            shopCosts[3] += 5;
        }
    }

    public void UpgradeFireRate()
    {
        if(_GM.money >= shopCosts[4])
        {
            gun.timeBetweenShots -= 0.02f;
            shopCosts[4] += 5;
        }
        
    }

    public void Heal()
    {
        if(_GM.money >= shopCosts[5])
        {
            _P.currentHealth = _P.maxHealth;
        }
        
    }
}
