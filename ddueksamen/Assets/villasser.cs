using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class villasser : MonoBehaviour
{
    public bool maybe;
    public GameObject dia;
    public GameObject dia1;
    teleport teleport;
    inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        teleport = FindObjectOfType<teleport>();
        inventory = FindObjectOfType<inventory>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerStay(Collider other)
    {
       if (other.tag == ("Player") && Input.GetKey(KeyCode.E) && teleport.explored)
        {
            dia.SetActive(true);
        }
        if (other.tag == ("Player") && Input.GetKey(KeyCode.E) && teleport.explored && inventory.items.Contains("Chest Parent 001"))
        {
            SceneManager.LoadScene(1/*Put the number here*/);
        }

    }
}
