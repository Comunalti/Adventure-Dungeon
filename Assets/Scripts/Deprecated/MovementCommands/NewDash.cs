using System;
using System.Collections;
using System.Collections.Generic;
using Energy;
using Health;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class NewDash : MonoBehaviour
{
    [SerializeField] private HealthController healthController;
    private Rigidbody2D _rigidbody2D;
    public EnergyController energy;
    [SerializeField] private float dashSpeed = 1;
    private Vector2 _direction;
    [SerializeField] private bool canDash;
    [SerializeField] private float dashDelay = 1;
    [SerializeField] private float dashCost = 2;
    [SerializeField] private float invincibilityTime = 1;
    public event Action DashFireEvent;
    public event Action DashFailEvent;
    
    private IEnumerator ResetInvincibility()
    {
        yield return new WaitForSeconds(invincibilityTime);
        healthController.isInvincible = false;
    }
    private IEnumerator ResetDash()
    {
        yield return new WaitForSeconds(dashDelay);
        canDash = true;
    }
    

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
        _direction = obj;
    }

    private void OnDash()
    {
        if (canDash && energy.GetEnergy() >= dashCost)
        {
            _rigidbody2D.AddForce(_direction * dashSpeed, ForceMode2D.Impulse);
            canDash = false;
            healthController.isInvincible = true;
            StartCoroutine(ResetDash());
            StartCoroutine(ResetInvincibility());
            energy.AddCurrentEnergy(-dashCost);
            
            Debug.Log("Dash");
            DashFireEvent?.Invoke();
        }
        else
        {
            DashFailEvent?.Invoke();
        }
    }
}
