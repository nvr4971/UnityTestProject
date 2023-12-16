using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRepairPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Picked up FullRepairPickup");

        PlayerStats.Instance.FullRepairDamage();

        Destroy(gameObject);
    }
}
