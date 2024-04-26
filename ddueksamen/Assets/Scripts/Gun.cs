using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage;
    public float range;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }
    void Shoot()
    {
        RaycastHit hit;
        //iPhysics.Raycast(fpsCam.transform.position);
    }
}
