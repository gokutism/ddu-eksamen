using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTrans : MonoBehaviour
{

    public int waitCount = 5;
    public int switcher;

    private void Start()
    {
        StartCoroutine(going());
    }

    private IEnumerator going()
    {
        yield return new WaitForSeconds(waitCount);
        SceneManager.LoadScene(2);
    }
}
