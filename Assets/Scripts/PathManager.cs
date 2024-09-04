using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] GameObject[] pathPrefabs;
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] Transform player;

    int initialPaths = 20;
    float spawnZ = 0f;

    // Path dimensions for prefab position calculations
    float pathLength = 3f;
    float pathWidth = 18f;

    Queue<GameObject> activePaths = new Queue<GameObject>();

    void Start()
    {
        // Pre-spawn the initial paths
        for (int i = 0; i < initialPaths; i++)
        {
            SpawnPath();
        }
    }

    void Update()
    {
        // Keep the initial number of paths ahead of player at all times
        if (player.position.z + pathLength * initialPaths > spawnZ)
        {
            SpawnPath();
            SpawnObstacle();
            RemoveOldPath();
        }
    }

    void SpawnPath()
    {
        GameObject randomPathPrefab = pathPrefabs[Random.Range(0, pathPrefabs.Length)];

        // Spawn the prefab at the correct position based on spawnZ
        Vector3 spawnPosition = new Vector3(0, 0, spawnZ);
        GameObject pathPiece = Instantiate(randomPathPrefab, spawnPosition, randomPathPrefab.transform.rotation);

        // Add the newly spawned prefab to the queue
        activePaths.Enqueue(pathPiece);

        // Move the spawnZ forward for the next prefab
        spawnZ += pathLength;        
    }

    void SpawnObstacle()
    {
        GameObject randomObstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Calculate obstacle position with random X
        float randomXPosition = Random.Range(0, pathWidth);
        Vector3 obstaclePosition = new Vector3(randomXPosition, 0, spawnZ);

        Instantiate(randomObstaclePrefab, obstaclePosition, randomObstaclePrefab.transform.rotation);
    }

    void RemoveOldPath()
    {
        // If there are more prefabs than we need, remove the oldest one
        if (activePaths.Count > initialPaths + 5) // Keep some behind the player to prevent camera from seeing the glitches
        {
            GameObject oldPathPiece = activePaths.Dequeue();
            Destroy(oldPathPiece);
        }
    }
}
