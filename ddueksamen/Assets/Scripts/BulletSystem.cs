using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    public ThirdPersonController playerHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (playerHealth = null)
            {
                playerHealth = collision.gameObject.GetComponent<ThirdPersonController>();
            }
            playerHealth.GetComponent<IDamageable>()?.TakeDamage(damage);
            playerHealth.TakeDamage(damage);
        }
        
    }
}
