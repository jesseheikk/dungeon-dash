using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;

    float distanceFromPlayer = 5f;

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(player.position.x, transform.position.y, player.position.z - distanceFromPlayer);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPosition, 0.125f);
        transform.position = smoothedPosition;
    }
}

