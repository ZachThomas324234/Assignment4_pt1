using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemyCount = 3;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        int enemyCount = 0;

        while (enemyCount < maxEnemyCount)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-5, 5), 2, Random.Range(-25, -15));
            GameObject clone = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            
            // Make sure to set the unique health variables for each enemy
            LightEnemy lightEnemyScript = clone.GetComponent<LightEnemy>();
            lightEnemyScript.InitializeHealth();

            yield return new WaitForSeconds(0.5f);
            enemyCount++;
        }
    }
}