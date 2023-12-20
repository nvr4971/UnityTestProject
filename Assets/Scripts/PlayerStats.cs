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

    private void Start()
    {
        UIManager.Instance.UpdatePositionUI(1);
        UIManager.Instance.UpdateSpeedUI(0f);

        UIManager.Instance.UpdateDamageUI(damage);

        UIManager.Instance.UpdateCurrentFuelUI(fuel);
        UIManager.Instance.UpdateMaxFuelUI(fuelCap);

        UIManager.Instance.UpdateCurrentLapUI(lap);
        UIManager.Instance.UpdateMaxLapUI(lapsToFinish);
    }

    public void TakeDamage(int amount)
    {
        damage += amount;

        if (damage >= damageCap)
        {
            // Reset scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        UIManager.Instance.UpdateDamageUI(damage);
    }

    public void RepairDamage(int amount)
    {
        damage -= amount;

        if (damage < 0)
        {
            damage = 0;
        }

        UIManager.Instance.UpdateDamageUI(damage);
    }

    public void FullRepairDamage()
    {
        damage = 0;

        UIManager.Instance.UpdateDamageUI(damage);
    }

    public void AddFuel(int amount)
    {
        fuel += amount;

        if (fuel >= fuelCap)
        {
            fuel = fuelCap;
        }

        UIManager.Instance.UpdateCurrentFuelUI(fuel);
    }

    public void AddFuelCap(int amount)
    {
        fuelCap += amount;

        UIManager.Instance.UpdateMaxFuelUI(fuelCap);
    }

    public void AddLap()
    {
        lap++;

        if (lap >= lapsToFinish)
        {
            Debug.Log("Level Complete!");
        }

        UIManager.Instance.UpdateCurrentLapUI(lap);
    }
}
