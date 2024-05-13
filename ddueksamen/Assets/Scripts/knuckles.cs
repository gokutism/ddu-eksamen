using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knuckles : MonoBehaviour
{
public bool maybe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == ("Player") && Input.GetKeyDown("e"))
        {
            Destroy(gameObject);
            maybe = true;
        }
        }
}
