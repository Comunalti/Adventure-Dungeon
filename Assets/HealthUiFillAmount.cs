using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUiFillAmount : MonoBehaviour
{
    public Health health;
    public Image image;
    
    private void OnEnable()
    {
        health.TookDamageEvent += OnDamage;
    }

    private void OnDisable()
    {
        health.TookDamageEvent -= OnDamage;
    }

    private void OnDamage(float obj)
    {
        image.fillAmount = health.GetPercentage();
    }
}