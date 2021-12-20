using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GameBehaviour
{
    /*Bullet stats
      speed is bullet velocity
      lifetime is how long the bullet will fly before dissapearing
      damage is how much damage the bullet does*/
    [HideInInspector]
    public float speed;

    public float lifeTime;
    public int damage;

    public GameObject impactEffect;


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    //checks what the bullet collides with and does a respective function
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
           // Debug.Log("enemy hit");
            collision.gameObject.GetComponent<Enemy>().HurtEnemy(damage);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
        }


    }
}
