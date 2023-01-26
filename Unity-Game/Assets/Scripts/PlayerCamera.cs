using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    
    Transform playerTransform;
    Vector3 Offset;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        transform.position = playerTransform.position + Offset;
    }
}
