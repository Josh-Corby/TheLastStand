using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : GameBehaviour
{
    //how much damage the enemies do
    public int damage;
    public void OnTriggerEnter(Collider other)
    {
        //enemy calls the damage function when it collides with the player
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damage);
        }
    }
}
