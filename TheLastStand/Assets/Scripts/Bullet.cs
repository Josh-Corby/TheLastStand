using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GameBehaviour
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
        if(collision.gameObject.tag == "Enemy")
        {
           // Debug.Log("enemy hit");
            collision.gameObject.GetComponent<Enemy>().HurtEnemy(damage);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
