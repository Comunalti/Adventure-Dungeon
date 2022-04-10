using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class InputManager : LazySingleton<InputManager> , ControlMap.IMouseMapActions , ControlMap.IMovimentMapActions
{
    public event Action MouseLeftClickEvent;
    public event Action MouseRightClickEvent;
    public event Action MouseMiddleClickEvent;
    public event Action MouseMovedEvent;
    public event Action DirectionChangedEvent;

    private ControlMap _controlMap;

    private void Start()
    {
        _controlMap = new ControlMap();
        _controlMap.MouseMap.SetCallbacks(this);
        _controlMap.MovimentMap.SetCallbacks(this);
        _controlMap.Enable();
    }


    private void OnDestroy()
    {
        _controlMap.Dispose();
    }

    public void OnRightClickAction(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        print("OnRightClickAction");
        MouseRightClickEvent?.Invoke();
    }

    public void OnLeftClickAction(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        print("OnLeftClickAction");
        MouseLeftClickEvent?.Invoke();
    }

    public void OnMiddleClickAction(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        print("OnMiddleClickAction");
        MouseMiddleClickEvent?.Invoke();
    }

    public void OnMouseMove(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        print("OnMouseMove");
        MouseMovedEvent?.Invoke();
    }

    public void OnDirection(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        print("OnDirection");
        DirectionChangedEvent?.Invoke();
    }
}