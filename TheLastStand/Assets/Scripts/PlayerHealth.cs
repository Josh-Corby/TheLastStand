using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Singleton<PlayerHealth>
{
    //player health stats
    public int maxHealth;
    public float currentHealth;

    //values for when the player flashes when taking damage
    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;
    void Start()
    {
        //health is set to max at the start of the game
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }

    void Update()
    {
        //if player health is 0 the player dies
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if(flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                //colur used for the flash
                rend.material.SetColor("_Color", storedColor);
            }
        }
    }

    //function used to damage the player when called
    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.white);
    }
}
