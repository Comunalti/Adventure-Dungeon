using System;
using Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Managers
{
    public class InputManager : LazySingleton<InputManager> , ControlMap.IMouseMapActions , ControlMap.IMovimentMapActions, ControlMap.IKeyboardMapActions
    {
        public event Action MouseLeftClickEvent;
        public event Action MouseLeftClickEndedEvent;

        public event Action MouseRightClickEvent;
        public event Action MouseRightClickEndedEvent;
        public event Action MouseMiddleClickEvent;
        public event Action<bool> WheelScrolledEvent;
        public event Action EPressEvent;
        public event Action QPressEvent;
        public event Action RPressEvent;
        public event Action FPressEvent;
        public event Action EscPressEvent;
        public event Action XPressEvent;

        public event Action AltPressEnddedEvent;
        public event Action<bool> AltChangedEvent;
        public event Action AltPressEvent;
        public event Action<int> NumberPressEvent;
        public event Action<Vector2> MouseMovedEvent;
        public event Action<Vector2> DirectionChangedEvent;

        public event Action DashEvent;
        public event Action DashStopEvent;


        public ControlMap controlMap;

        private void Start()
        {
            if (created)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                created = true;
                DontDestroyOnLoad(gameObject);
            }
            controlMap = new ControlMap();
            controlMap.MouseMap.SetCallbacks(this);
            controlMap.MovimentMap.SetCallbacks(this);
            controlMap.KeyboardMap.SetCallbacks(this);
            controlMap.Enable();
        }


        private void OnDestroy()
        {
            controlMap?.Dispose();
        }

        public void OnRightClickAction(InputAction.CallbackContext context)
        {
            if (context.performed)
                MouseRightClickEvent?.Invoke();
            else if (context.canceled)
            {
                MouseRightClickEndedEvent?.Invoke();
            }
            //print("OnRightClickAction");
            
        }

        public void OnLeftClickAction(InputAction.CallbackContext context)
        {
           
            if (context.performed)
            {
                MouseLeftClickEvent?.Invoke();
            }
            else if (context.canceled)
            {
                MouseLeftClickEndedEvent?.Invoke();
            }
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

        public void OnScroll(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            if (context.performed)
            {
                WheelScrolledEvent?.Invoke(value>=0);
            }
        }

        public void OnDirection(InputAction.CallbackContext context)
        {
            
            //print("OnDirection");
            DirectionChangedEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnDashAction(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && context.performed)
            {
                DashEvent?.Invoke();
            }else if (context.canceled)
            {
                DashStopEvent?.Invoke();
            }
        }

        

        public void OnNumberPressed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                var value = int.Parse(context.control.name);
                NumberPressEvent?.Invoke(value);
            }
        }
        public void OnEPressAction(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && context.performed)
            {
                EPressEvent?.Invoke();
            }
        }

        public void OnQPressAction(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && context.performed)
            {
                QPressEvent?.Invoke();
            }        
        }

        public void OnRPressAction(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && context.performed)
            {
                RPressEvent?.Invoke();
            }        
        }

        public void OnFPressAction(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && context.performed)
            {
               FPressEvent?.Invoke();
            }        
        }
        public void OnXPressAction(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && context.performed)
            {
                XPressEvent?.Invoke();
            }    
        }

        public void OnEscPressAction(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && context.performed)
            {
                EscPressEvent?.Invoke();
            }    
        }

        public void OnAltPressAction(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && context.performed)
            {
                AltPressEvent?.Invoke();
                AltChangedEvent?.Invoke(true);
                //print("pressed alt");
            }
            else if(!context.ReadValueAsButton())
            {
                AltPressEnddedEvent?.Invoke();
                AltChangedEvent?.Invoke(false);
                //print("unpressed alt");
            }
            
        }

        
    }
}