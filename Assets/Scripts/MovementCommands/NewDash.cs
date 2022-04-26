using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class NewDash : MonoBehaviour
{
    
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float dashSpeed = 1;
    [SerializeField] private Vector2 direction;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        InputManager.Instance.DashEvent += OnDash;
        InputManager.Instance.DirectionChangedEvent += OnDirectionChanged;
    }

    private void OnDisable()
    {
        InputManager.Instance.DashEvent -= OnDash;
        InputManager.Instance.DirectionChangedEvent -= OnDirectionChanged;
    }

    private void OnDirectionChanged(Vector2 obj)
    {
        direction = obj;
    }

    private void OnDash()
    {
        _rigidbody2D.AddForce(direction * dashSpeed, ForceMode2D.Impulse);
        print("Dash");
    }
}
