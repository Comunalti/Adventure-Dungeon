using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMover : MonoBehaviour
{
    public Stateless finalStateless;

    public Vector2 direction;
    [SerializeField] private float speed = 1;

    private void Start()
    {
        finalStateless.StatelessChanged += OnStatelessChanged;
    }

    private void OnStatelessChanged()
    {
        direction = finalStateless.GetMaxInterpolatedVector();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3)direction*(Time.deltaTime*speed);
    }
}
