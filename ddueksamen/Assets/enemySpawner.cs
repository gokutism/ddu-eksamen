using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < 100)
        {
            xPos = Random.Range(-500, 500);
            zPos = Random.Range(-500, 500);
            Instantiate(theEnemy, new Vector3(xPos, -5, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1);
            EnemyCount += 1;
        }
    }
}
