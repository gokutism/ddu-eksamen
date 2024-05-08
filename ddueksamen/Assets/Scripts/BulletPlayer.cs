using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Projectile")
        {
            gameObject.transform.parent = other.gameObject.transform;
            Destroy(gameObject);
            //GetComponent<BoxCollider>().enabled = false;

        }
        if (other.tag == "Enemy")
        {
            var healthComponent = other.GetComponent<EnemyFu>();
            if (healthComponent != null)
            {
                //healthComponent.TakeDamage(1);
                other.gameObject.GetComponent<IDamageable>()?.TakeDamage();
            }
        }
    }
    /* private void OnCollisionEnter(Collision collision)
     {

         if(collision.gameObject.TryGetComponent<EnemyFu>(out EnemyFu enemyComponent))
         {
             enemyComponent.TakeDamage(1);
         }
         Destroy(gameObject);
     }()*/
}


