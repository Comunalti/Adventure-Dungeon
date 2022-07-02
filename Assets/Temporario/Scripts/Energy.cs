using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [SerializeField] private float MaxEnergy = 10.0f;
    [SerializeField] private float CurrentEnergy = 0;
    [SerializeField] private float RechargeSpeed = 1;

    public event Action<float> EnergyRechargeEvent;
    public event Action<float> EnergyUseEvent;

    private void Start()
    {
        //CurrentEnergy = MaxEnergy;
    }

    private void Update()
    {
        Add(RechargeSpeed * Time.deltaTime);
    }

    public void Add(float quantity)
    {
        CurrentEnergy = Mathf.Clamp(CurrentEnergy + quantity, 0, MaxEnergy);
        EnergyRechargeEvent?.Invoke(quantity);
        
    }

    public void Remove(float quantity)
    {
        CurrentEnergy = Mathf.Clamp(CurrentEnergy - quantity, 0, MaxEnergy);
        EnergyUseEvent?.Invoke(quantity);
    }
    
    public float GetPercentage()
    {
        return CurrentEnergy / MaxEnergy;
    }

    
    public bool Have(float energyCost)
    {
        return CurrentEnergy > energyCost;
    }
}
