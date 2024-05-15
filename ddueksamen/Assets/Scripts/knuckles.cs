using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knuckles : MonoBehaviour
{
    public bool maybe;
    public GameObject dia;
    public GameObject dia1;
    teleport teleport;

    // Start is called before the first frame update
    void Start()
    {
        teleport = FindObjectOfType<teleport>();
    }

    // Update is called once per frame
    void Update()
    {
     }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == ("Player") && Input.GetKey(KeyCode.E))
        {
           dia.SetActive(true);
           maybe = true;
        }
        if (other.tag == ("Player") && Input.GetKey(KeyCode.E) && teleport.explored)
        { 
            dia1.SetActive(true);
        }

    }
}
