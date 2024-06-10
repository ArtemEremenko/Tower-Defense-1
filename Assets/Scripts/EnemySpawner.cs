using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyZerglingPrefab;
    private float spawnTimer = 0;
    [SerializeField] private float spawnResetTimer = 3;
    [SerializeField] private Transform waypointsParent;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        
        if (spawnTimer >= spawnResetTimer)
        {
            SpawnEnemyUnit();
            spawnTimer = 0;
        }
    }

    private void SpawnEnemyUnit()
    {
        Enemy enemyUnit = Instantiate(enemyZerglingPrefab, transform.position, transform.rotation);
        
        enemyUnit.Initialize(waypointsParent);
    }
}
