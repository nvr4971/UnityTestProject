using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Picked up FuelPickup1");

        PlayerStats.Instance.AddFuel(25);

        Destroy(gameObject);
    }
}
