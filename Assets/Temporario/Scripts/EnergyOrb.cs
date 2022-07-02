using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnergyOrb : MonoBehaviour
{
    public float quantity = 1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        var energy = col.gameObject.GetComponent<Energy>();

        if (energy != null)
        {
            energy.Add(quantity);
            Destroy(gameObject);
        }
    }
}
