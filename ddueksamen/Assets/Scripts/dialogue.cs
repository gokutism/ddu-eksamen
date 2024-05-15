using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class dialogue : MonoBehaviour
{
    public TextMeshProUGUI textcomp;
    public string[] lines;
    public float textspeed;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textcomp.text = string.Empty;
        Startdialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textcomp.text == lines[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textcomp.text = lines[index];
            }
        }
    }
    void Startdialog() 
    {
        index = 0;
        StartCoroutine(Typeline());
    }
    IEnumerator Typeline()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textcomp.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void nextLine()
    {
        if (index < lines.Length -1) 
        {
            index++;
            textcomp.text = string.Empty;
            StartCoroutine(Typeline());
           
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
