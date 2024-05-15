using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    private Collision _collider;
    public GameObject entrance;
    knuckles knuckles;
    public bool explored;
    // Start is called before the first frame update
    void Start()
    {
       knuckles = FindObjectOfType<knuckles>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player") && knuckles.maybe)
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            cc.enabled = false;
            other.transform.position = entrance.transform.position;
            cc.enabled = true;
            explored = true;
        }
    }
}
