using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [SerializeField] private float maxEnergy = 10.0f;
    [SerializeField] private float currentEnergy;
    [SerializeField] private float rechargeSpeed = 1;

    public event Action<float> CurrentEnergyChangeEvent;
    // public event Action<float> EnergyUseEvent;

    private void Start()
    {
        // CurrentEnergy = MaxEnergy;
    }

    private void Update()
    {
        AddToCurrentEnergy(rechargeSpeed * Time.deltaTime);
    }

    public void AddToCurrentEnergy(float quantity)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + quantity, 0, maxEnergy);
        CurrentEnergyChangeEvent?.Invoke(quantity);
    }

    public float GetPercentage()
    {
        return currentEnergy / maxEnergy;
    }

    public float GetEnergy()
    {
        return currentEnergy;
    }
}
