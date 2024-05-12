using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    inventory myinven;

    private void Start()
    {
        myinven = FindObjectOfType<inventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            Destroy(gameObject);
            myinven.Keep();
        }

    }
    void Update()
    {
       
    }



}
