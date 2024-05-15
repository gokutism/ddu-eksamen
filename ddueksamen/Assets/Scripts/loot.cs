using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loot : MonoBehaviour
{
    inventory myinven;
   public bool d;

    private void Start()
    {
        myinven = FindObjectOfType<inventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            d = true;
            myinven.Keep();
        }

    }
    void Update()
    {

    }



}