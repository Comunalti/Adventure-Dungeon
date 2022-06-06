using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [SerializeField] private float MaxEnergy = 10.0f;
    [SerializeField] private float CurrentEnergy;
    [SerializeField] private float RechargeSpeed = 1;

    public event Action<float> EnergyRechargeEvent;
    public event Action<float> EnergyUseEvent;

    private void Start()
    {
        //CurrentEnergy = MaxEnergy;
    }

    private void Update()
    {
        EnergyRecharge(RechargeSpeed * Time.deltaTime);
    }

    public void EnergyRecharge(float quantity)
    {
        CurrentEnergy = Mathf.Clamp(CurrentEnergy + quantity, 0, MaxEnergy);
        EnergyRechargeEvent?.Invoke(quantity);
        
    }

    public void EnergyUse(float quantity)
    {
        CurrentEnergy -= quantity;
        EnergyUseEvent?.Invoke(quantity);
    }
    
    public float GetPercentage()
    {
        return CurrentEnergy / MaxEnergy;
    }

}
