using System;
using Managers;
using MovementCommands;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    public MovementCommand movementCommand;
    private Vector2 _direction;

    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (movementCommand is null)
            return;
            
        movementCommand.Move(_rigidbody2D,_direction);
    }

    private void OnEnable()
    {
        InputManager.Instance.DirectionChangedEvent += OnDirectionChanged;
    }

    private void OnDisable()
    {
        InputManager.Instance.DirectionChangedEvent -= OnDirectionChanged;
    }

    private void OnDirectionChanged(Vector2 direction)
    {
        _direction = direction;
    }

}
