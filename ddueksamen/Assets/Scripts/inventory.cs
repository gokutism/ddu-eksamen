using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public List<string> items;
    pickup pickup;
    loot loot;

    // Start is called before the first frame update
    void Start()
    {
        pickup = FindObjectOfType<pickup>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void Keep()
    {
        
        items.Add(pickup.name);
        items.Add(loot.name);
        
    }

}
