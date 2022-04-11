using System;
using Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class InputManager : LazySingleton<InputManager> , ControlMap.IMouseMapActions , ControlMap.IMovimentMapActions
    {
        public event Action MouseLeftClickEvent;
        public event Action MouseRightClickEvent;
        public event Action MouseMiddleClickEvent;
        public event Action<Vector2> MouseMovedEvent;
        public event Action<Vector2> DirectionChangedEvent;

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
        
            //print("OnRightClickAction");
            MouseRightClickEvent?.Invoke();
        }

        public void OnLeftClickAction(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;
        
            //print("OnLeftClickAction");
            MouseLeftClickEvent?.Invoke();
        }

        public void OnMiddleClickAction(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;
        
            //print("OnMiddleClickAction");
            MouseMiddleClickEvent?.Invoke();
        }

        public void OnMouseMove(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;
        
            //print("OnMouseMove");
            MouseMovedEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnDirection(InputAction.CallbackContext context)
        {
            
            //print("OnDirection");
            DirectionChangedEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }
}