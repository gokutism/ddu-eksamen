using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectileYes : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    public float speed;
    [SerializeField] private Transform ptkcolor1;
    [SerializeField] private Transform ptkcolor2;
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
       
        bulletRigidbody.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BulletTarget>() != null)
        {
            Instantiate(ptkcolor1, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(ptkcolor2, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
