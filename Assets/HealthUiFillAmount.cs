using System;
using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;
using UnityEngine.UI;

public class HealthUiFillAmount : MonoBehaviour
{
    public HealthController healthController;
    public Image image;
    
    private void OnEnable()
    {
        healthController.HpChangedEvent += OnDamage;
    }

    private void OnDisable()
    {
        healthController.HpChangedEvent -= OnDamage;
    }

    private void OnDamage(float obj)
    {
        image.fillAmount = healthController.GetPercentage();
    }
}