using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Lap complete!");

        PlayerStats.Instance.AddLap();
    }
}
