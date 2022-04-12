﻿using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Health health;
    public Slider slider;

    private void OnEnable()
    {
        health.TookDamageEvent += RefreshUI;
    }

    private void OnDisable()
    {
        health.TookDamageEvent -= RefreshUI;
    }
    
    
    private void RefreshUI(float dmg)
    {
        slider.value = health.GetPercentage();
    }
}