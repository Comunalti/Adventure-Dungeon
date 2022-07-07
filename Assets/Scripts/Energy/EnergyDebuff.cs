using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDebuff : MonoBehaviour
{
    [SerializeField] private float value;
    [SerializeField] private float delayInSeconds;
    private void OnTriggerEnter2D(Collider2D col)
    {
        var energy = col.gameObject.GetComponent<Energy>();

        if (energy == null) return;
        // StartCoroutine(energy.SetNerf(value, delayInSeconds));
        Destroy(gameObject);
    }
}
