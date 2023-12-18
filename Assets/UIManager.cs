using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text currentLapUI;
    [SerializeField] private TMP_Text maxLapUI;

    [SerializeField] private TMP_Text positionUI;

    [SerializeField] private TMP_Text speedUI;

    [SerializeField] private TMP_Text damageUI;

    [SerializeField] private TMP_Text currentFuelUI;
    [SerializeField] private TMP_Text maxFuelUI;

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateCurrentLapUI(int currentLap)
    {
        currentLapUI.text = currentLap.ToString();
    }

    public void UpdateMaxLapUI(int maxLap)
    {
        maxLapUI.text = maxLap.ToString();
    }

    public void UpdatePositionUI(int position)
    {
        positionUI.text = position.ToString();
    }

    public void UpdateSpeedUI(float speed)
    {
        speedUI.text = speed.ToString();
    }

    public void UpdateDamageUI(int damage)
    {
        damageUI.text = damage.ToString();
    }

    public void UpdateCurrentFuelUI(int currentFuel)
    {
        currentFuelUI.text = currentFuel.ToString();
    }

    public void UpdateMaxFuelUI(int maxFuel)
    {
        maxFuelUI.text = maxFuel.ToString();
    }
}
