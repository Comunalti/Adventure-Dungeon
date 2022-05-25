using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    public Energy energy;
    public Slider slider;

    private void OnEnable()
    {
        energy.EnergyRechargeEvent += RefreshUI;
        energy.EnergyUseEvent += RefreshUI;
    }

    private void OnDisable()
    {
        energy.EnergyRechargeEvent -= RefreshUI;
        energy.EnergyUseEvent -= RefreshUI;
    }

    private void RefreshUI(float quantity)
    {
        slider.value = energy.GetPercentage();
    }
}
