using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GrowingShaderHandler : MonoBehaviour
{

    public float max;
    public float current = 0;
    public float real;
    [SerializeField] private float speed;

    void RemoveHp(float quantity)
    {
        real += quantity;
        
    }

    private void Update()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var material = spriteRenderer.material;
        current = Mathf.Lerp(current, real, speed);
        material.SetFloat("_size",current/max);

        if (Math.Abs(current - max) < 0.5)
        {
            material.SetColor("_Color",Color.Lerp(material.GetColor("_Color"), Color.clear, speed));

            if (material.GetColor("_Color").r < 0.05)
            {
                real = 0;
                current = 0;
                material.SetColor("_Color",Random.ColorHSV());
            }
        }

        real = Mathf.Clamp(real, 0, max);
    }
}
