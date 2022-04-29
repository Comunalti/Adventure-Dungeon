using System;
using UnityEngine;

public class StatelessFollow: MonoBehaviour
{
    public Stateless stateless;
    public GameObject follow;
    [SerializeField] private float intensity;
    [SerializeField] private Vector2 direction;

    private void Update()
    {
        if (follow != null)
        {
            var ab = follow.transform.position - transform.position;
            direction = ab.normalized;
            intensity = ab.magnitude;
            
            stateless.ResetValues();

            stateless.AddVector(direction);
        }
    }
}