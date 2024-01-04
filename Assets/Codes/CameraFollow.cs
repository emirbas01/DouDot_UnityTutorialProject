using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;

    [SerializeField] Vector3 offset;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
