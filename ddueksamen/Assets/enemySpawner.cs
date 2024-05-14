using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public float xPos;
    public float zPos;
    public float yPos;
    public float minimumXPos;
    public float minimumZPos;
    public float minimumYPos;
    public float maximumXPos;
    public float maximumZPos;
    public float maximumYPos;
    public int maxEnemyCount;
    public float waitCount;

    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < maxEnemyCount)
        {
            xPos = Random.Range(minimumXPos, maximumXPos);
            zPos = Random.Range(minimumZPos, maximumZPos);
            yPos = Random.Range(minimumYPos, maximumYPos);
            Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(waitCount);
            EnemyCount += 1;
        }
    }
}
