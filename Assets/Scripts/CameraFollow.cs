using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;   // Reference to the player
    float offSet = -5f;

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, player.position.z + offSet);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
        transform.position = smoothedPosition;
    }
}

