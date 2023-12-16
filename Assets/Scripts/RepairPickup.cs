using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Picked up RepairPickup");

        PlayerStats.Instance.RepairDamage(30);

        Destroy(gameObject);
    }
}
