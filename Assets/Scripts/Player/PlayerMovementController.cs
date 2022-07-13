using System;
using Managers;
using MovementCommands;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{

    public MovementCommand movementCommand;
    private Vector2 _direction;
    public float speed;
    private Vector3 lastFramePosition;
    
    public bool isWalking;

    private Rigidbody2D _rigidbody2D;


    public event Action StartWalkingEvent;
    public event Action StopWalkingEvent;
    public event Action<bool> WalkingChangedEvent; 
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(_direction*speed*Time.deltaTime);
        
        var deltaPosition = transform.position - lastFramePosition;
        var walkingLastFrame = isWalking;
        
        if (deltaPosition.magnitude > 0.0001)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if (isWalking && !walkingLastFrame)
        {
            StartWalkingEvent?.Invoke();
            WalkingChangedEvent?.Invoke(true);
        }
        else if(!isWalking && walkingLastFrame)
        {
            StopWalkingEvent?.Invoke();
            WalkingChangedEvent?.Invoke(false);
        }

        lastFramePosition = transform.position;
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

