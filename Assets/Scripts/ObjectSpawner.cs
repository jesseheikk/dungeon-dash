using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] Transform player;

    float spawnDistance = 50f;
    float spawnZ = 0f;

    void Update()
    {
        if (player.position.z + spawnDistance > spawnZ)
        {
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        GameObject randomPathPrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Vector3 spawnPosition = new Vector3(0, 0, spawnZ);

        GameObject obj = Instantiate(randomPathPrefab, spawnPosition, Quaternion.identity);
        
        spawnZ += 10f;
    }
}

