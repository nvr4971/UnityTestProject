using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        //transform.SetPositionAndRotation(
        //    player.transform.position + offset, 
        //    Quaternion.Euler(transform.eulerAngles.x, player.transform.eulerAngles.y, transform.eulerAngles.z)
        //);

        transform.position = player.transform.position + offset;
    }
}