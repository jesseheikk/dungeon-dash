using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] GameObject[] pathPrefabs;
    [SerializeField] GameObject emptyPathPrefab;
    [SerializeField] Transform player;

    // Path dimensions for prefab position calculations
    float pathLength = 15f;
    float pathWidth = 18f;
    float spawnZ = 0f;
    float spawnX = 0f;
    int initialPaths = 10;

    Queue<GameObject> activePaths = new Queue<GameObject>();

    void Start()
    {
        spawnX = player.position.x - pathWidth / 2;

        // Pre-spawn the initial empty paths
        for (int i = 0; i < initialPaths; i++)
        {
            SpawnPath(emptyPathPrefab);
        }
    }

    void Update()
    {
        // Keep the initial number of paths ahead of player at all times
        if (player.position.z + pathLength * initialPaths > spawnZ)
        {
            GameObject randomPathPrefab = pathPrefabs[Random.Range(0, pathPrefabs.Length)];
            SpawnPath(randomPathPrefab);
            RemoveOldPath();
        }
    }

    void SpawnPath(GameObject pathPrefab)
    {
        // Spawn the prefab at the correct position based on spawnZ
        Vector3 spawnPosition = new Vector3(spawnX, 0, spawnZ);
        GameObject pathPiece = Instantiate(pathPrefab, spawnPosition, pathPrefab.transform.rotation);

        // Add the newly spawned prefab to the queue
        activePaths.Enqueue(pathPiece);

        // Move the spawnZ forward for the next prefab
        spawnZ += pathLength;        
    }

    void RemoveOldPath()
    {
        // If there are more prefabs than we need, remove the oldest one
        if (activePaths.Count > initialPaths + 2) // Keep some behind the player to prevent camera from seeing the glitches
        {
            GameObject oldPathPiece = activePaths.Dequeue();
            Destroy(oldPathPiece);
        }
    }
}
