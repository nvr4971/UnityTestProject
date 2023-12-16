using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Picked up FuelPickup2");

        PlayerStats.Instance.AddFuelCap(10);

        Destroy(gameObject);
    }
}
