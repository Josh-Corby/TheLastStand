using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : GameBehaviour
{
    public int damage;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damage);
        }
    }
}
