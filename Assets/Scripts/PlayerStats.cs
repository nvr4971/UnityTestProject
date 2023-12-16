using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    [SerializeField] private int damage;
    [SerializeField] private int damageCap;

    [SerializeField] private int fuel;
    [SerializeField] private int fuelCap;

    [SerializeField] private int lap;
    [SerializeField] private int lapsToFinish;

    private void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(int amount)
    {
        damage += amount;

        if (damage >= damageCap)
        {
            // Reset scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void RepairDamage(int amount)
    {
        damage -= amount;

        if (damage < 0)
        {
            damage = 0;
        }
    }

    public void FullRepairDamage()
    {
        damage = 0;
    }

    public void AddFuel(int amount)
    {
        fuel += amount;

        if (fuel >= fuelCap)
        {
            fuel = fuelCap;
        }
    }

    public void AddFuelCap(int amount)
    {
        fuelCap += amount;
    }

    public void AddLap()
    {
        lap++;

        if (lap >= lapsToFinish)
        {
            Debug.Log("Level Complete!");
        }
    }
}
