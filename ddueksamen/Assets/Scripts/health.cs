using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour, IDamageable
{
    public float maxHealth;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
