using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarUiHandler : MonoBehaviour
{
    public Energy energy;
    public Image image;

    private void OnEnable()
    {
        energy.CurrentEnergyChangeEvent += UpdateUI;
    }

    private void OnDisable()
    {
        energy.CurrentEnergyChangeEvent -= UpdateUI;
    }

    public void UpdateUI(float f)
    {
        image.fillAmount = energy.GetPercentage();
    }
}
