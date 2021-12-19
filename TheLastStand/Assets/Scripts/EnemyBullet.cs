using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : GameBehaviour
{

    //enemy bullet stats
    public float speed;
    public float lifeTime;
    public int damage;

    //enemy bullet velocity function
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    //function for when the projectile hits the player
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit");
            collision.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damage);
            Destroy(this.gameObject);
        }

        // function for enemy bullets ignoring enemy collision
        if(collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
        }
    }
}
