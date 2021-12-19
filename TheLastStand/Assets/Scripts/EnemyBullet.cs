using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : GameBehaviour
{
    public float speed;

    public float lifeTime;

    public int damage;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit");
            collision.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damage);
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
        }
    }
}
