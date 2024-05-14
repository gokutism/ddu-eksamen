using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int yPos;
    public int minimumXPos;
    public int minimumZPos;
    public int minimumYPos;
    public int maximumXPos;
    public int maximumZPos;
    public int maximumYPos;
    public int maxEnemyCount;

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
            yield return new WaitForSeconds(1);
            EnemyCount += 1;
        }
    }
}
