using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFu : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {

            Destroy(gameObject);
            Debug.Log("ha loser");
        }
        Debug.Log("hit");
    }
}
