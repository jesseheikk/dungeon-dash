using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;

    public static CameraController Instance { get; private set; }
    bool useMenuMode = true;

    Vector3 offSet;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        offSet = new Vector3(-1f, 2f, -5f);
    }

    void LateUpdate()
    {
        //Vector3 newPosition = GetNewCameraPosition();
        Vector3 newPosition = player.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPosition, 0.125f);
        transform.position = smoothedPosition;
    }

    public void SetCameraOffSet(Vector3 newOffSet)
    {
        offSet = newOffSet;
    }
}
