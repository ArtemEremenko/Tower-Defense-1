using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyZerglingPrefab;
    [SerializeField] private float spawnTimer = 0;
    [SerializeField] private Transform waypointsParent;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        
        if (spawnTimer >= 3)
        {
            SpawnEnemyUnit();
            spawnTimer = 0;
        }
        // Spawn enemy from Start point
        //  delete enemy in Finish point
    }

    private void SpawnEnemyUnit()
    {
        Enemy enemyUnit = Instantiate(enemyZerglingPrefab, transform.position, transform.rotation);
        
        enemyUnit.Initialize(waypointsParent);
    }
}
