//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/ControlMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @ControlMap : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlMap"",
    ""maps"": [
        {
            ""name"": ""MouseMap"",
            ""id"": ""0a97937b-0ea6-4d2b-af33-66be659d6d77"",
            ""actions"": [
                {
                    ""name"": ""RightClickAction"",
                    ""type"": ""Button"",
                    ""id"": ""6e71c8d6-e7cc-4749-9f4d-083d12a1661d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftClickAction"",
                    ""type"": ""Button"",
                    ""id"": ""6a774b36-2c09-42f1-b9f7-35bd8b495f69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MiddleClickAction"",
                    ""type"": ""Button"",
                    ""id"": ""dc3b0a83-d2a2-458c-b650-e320899e4f70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseMove"",
                    ""type"": ""Value"",
                    ""id"": ""47784cf6-7fb1-4cf6-b190-d7a3b6e1f7f9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e72707b0-04b1-40ec-ab69-2c8648e427b5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClickAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4be665f-41c1-4275-a640-83b503c2c043"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClickAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22414a68-2dfc-4a87-85ca-179c99568d5e"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MiddleClickAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83d1825c-dca6-40aa-bcfd-699c41769fc5"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MovimentMap"",
            ""id"": ""8345b22b-94b8-45da-a61a-ad404436fec8"",
            ""actions"": [
                {
                    ""name"": ""Direction"",
                    ""type"": ""Value"",
                    ""id"": ""cd4491f9-121e-4839-afc7-47c9adfd9c0d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DashAction"",
                    ""type"": ""Button"",
                    ""id"": ""4421e6e2-a378-49e3-8658-dd7465a13298"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c77ab08b-2942-4141-9f3f-eba60f4dc4d4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7fb74db9-331c-46ed-841d-6027fdb7f603"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3e6584c6-e10e-4314-8911-c78a37f1f919"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c6503882-ae93-4e31-8561-597a5b1e6b7c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c5b4c264-117e-43ac-aa88-b82bae935971"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""69c184f1-85a5-4e0a-9ce3-557f2b22db86"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardMap"",
            ""id"": ""86e8d7bc-a56f-451d-b33e-02177e76b8cf"",
            ""actions"": [
                {
                    ""name"": ""EPressAction"",
                    ""type"": ""Button"",
                    ""id"": ""454f8ce8-b918-41c9-a5aa-8a9d0baa522c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bd4d1cef-35d9-41d8-8dee-cc6222667e9e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EPressAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InteractionMap"",
            ""id"": ""1efbcc72-bb68-4a79-9c21-28857407164e"",
            ""actions"": [
                {
                    ""name"": ""EscapeButton"",
                    ""type"": ""Button"",
                    ""id"": ""9a4a4357-d8b8-446d-82fd-7ff374444349"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""31b59489-2bff-4654-ad54-4b4c014f1dd6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EscapeButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MouseMap
        m_MouseMap = asset.FindActionMap("MouseMap", throwIfNotFound: true);
        m_MouseMap_RightClickAction = m_MouseMap.FindAction("RightClickAction", throwIfNotFound: true);
        m_MouseMap_LeftClickAction = m_MouseMap.FindAction("LeftClickAction", throwIfNotFound: true);
        m_MouseMap_MiddleClickAction = m_MouseMap.FindAction("MiddleClickAction", throwIfNotFound: true);
        m_MouseMap_MouseMove = m_MouseMap.FindAction("MouseMove", throwIfNotFound: true);
        // MovimentMap
        m_MovimentMap = asset.FindActionMap("MovimentMap", throwIfNotFound: true);
        m_MovimentMap_Direction = m_MovimentMap.FindAction("Direction", throwIfNotFound: true);
        m_MovimentMap_DashAction = m_MovimentMap.FindAction("DashAction", throwIfNotFound: true);
        // KeyboardMap
        m_KeyboardMap = asset.FindActionMap("KeyboardMap", throwIfNotFound: true);
        m_KeyboardMap_EPressAction = m_KeyboardMap.FindAction("EPressAction", throwIfNotFound: true);
        // InteractionMap
        m_InteractionMap = asset.FindActionMap("InteractionMap", throwIfNotFound: true);
        m_InteractionMap_EscapeButton = m_InteractionMap.FindAction("EscapeButton", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MouseMap
    private readonly InputActionMap m_MouseMap;
    private IMouseMapActions m_MouseMapActionsCallbackInterface;
    private readonly InputAction m_MouseMap_RightClickAction;
    private readonly InputAction m_MouseMap_LeftClickAction;
    private readonly InputAction m_MouseMap_MiddleClickAction;
    private readonly InputAction m_MouseMap_MouseMove;
    public struct MouseMapActions
    {
        private @ControlMap m_Wrapper;
        public MouseMapActions(@ControlMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightClickAction => m_Wrapper.m_MouseMap_RightClickAction;
        public InputAction @LeftClickAction => m_Wrapper.m_MouseMap_LeftClickAction;
        public InputAction @MiddleClickAction => m_Wrapper.m_MouseMap_MiddleClickAction;
        public InputAction @MouseMove => m_Wrapper.m_MouseMap_MouseMove;
        public InputActionMap Get() { return m_Wrapper.m_MouseMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseMapActions set) { return set.Get(); }
        public void SetCallbacks(IMouseMapActions instance)
        {
            if (m_Wrapper.m_MouseMapActionsCallbackInterface != null)
            {
                @RightClickAction.started -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnRightClickAction;
                @RightClickAction.performed -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnRightClickAction;
                @RightClickAction.canceled -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnRightClickAction;
                @LeftClickAction.started -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnLeftClickAction;
                @LeftClickAction.performed -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnLeftClickAction;
                @LeftClickAction.canceled -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnLeftClickAction;
                @MiddleClickAction.started -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnMiddleClickAction;
                @MiddleClickAction.performed -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnMiddleClickAction;
                @MiddleClickAction.canceled -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnMiddleClickAction;
                @MouseMove.started -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnMouseMove;
                @MouseMove.performed -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnMouseMove;
                @MouseMove.canceled -= m_Wrapper.m_MouseMapActionsCallbackInterface.OnMouseMove;
            }
            m_Wrapper.m_MouseMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RightClickAction.started += instance.OnRightClickAction;
                @RightClickAction.performed += instance.OnRightClickAction;
                @RightClickAction.canceled += instance.OnRightClickAction;
                @LeftClickAction.started += instance.OnLeftClickAction;
                @LeftClickAction.performed += instance.OnLeftClickAction;
                @LeftClickAction.canceled += instance.OnLeftClickAction;
                @MiddleClickAction.started += instance.OnMiddleClickAction;
                @MiddleClickAction.performed += instance.OnMiddleClickAction;
                @MiddleClickAction.canceled += instance.OnMiddleClickAction;
                @MouseMove.started += instance.OnMouseMove;
                @MouseMove.performed += instance.OnMouseMove;
                @MouseMove.canceled += instance.OnMouseMove;
            }
        }
    }
    public MouseMapActions @MouseMap => new MouseMapActions(this);

    // MovimentMap
    private readonly InputActionMap m_MovimentMap;
    private IMovimentMapActions m_MovimentMapActionsCallbackInterface;
    private readonly InputAction m_MovimentMap_Direction;
    private readonly InputAction m_MovimentMap_DashAction;
    public struct MovimentMapActions
    {
        private @ControlMap m_Wrapper;
        public MovimentMapActions(@ControlMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Direction => m_Wrapper.m_MovimentMap_Direction;
        public InputAction @DashAction => m_Wrapper.m_MovimentMap_DashAction;
        public InputActionMap Get() { return m_Wrapper.m_MovimentMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovimentMapActions set) { return set.Get(); }
        public void SetCallbacks(IMovimentMapActions instance)
        {
            if (m_Wrapper.m_MovimentMapActionsCallbackInterface != null)
            {
                @Direction.started -= m_Wrapper.m_MovimentMapActionsCallbackInterface.OnDirection;
                @Direction.performed -= m_Wrapper.m_MovimentMapActionsCallbackInterface.OnDirection;
                @Direction.canceled -= m_Wrapper.m_MovimentMapActionsCallbackInterface.OnDirection;
                @DashAction.started -= m_Wrapper.m_MovimentMapActionsCallbackInterface.OnDashAction;
                @DashAction.performed -= m_Wrapper.m_MovimentMapActionsCallbackInterface.OnDashAction;
                @DashAction.canceled -= m_Wrapper.m_MovimentMapActionsCallbackInterface.OnDashAction;
            }
            m_Wrapper.m_MovimentMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Direction.started += instance.OnDirection;
                @Direction.performed += instance.OnDirection;
                @Direction.canceled += instance.OnDirection;
                @DashAction.started += instance.OnDashAction;
                @DashAction.performed += instance.OnDashAction;
                @DashAction.canceled += instance.OnDashAction;
            }
        }
    }
    public MovimentMapActions @MovimentMap => new MovimentMapActions(this);

    // KeyboardMap
    private readonly InputActionMap m_KeyboardMap;
    private IKeyboardMapActions m_KeyboardMapActionsCallbackInterface;
    private readonly InputAction m_KeyboardMap_EPressAction;
    public struct KeyboardMapActions
    {
        private @ControlMap m_Wrapper;
        public KeyboardMapActions(@ControlMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @EPressAction => m_Wrapper.m_KeyboardMap_EPressAction;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardMapActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardMapActions instance)
        {
            if (m_Wrapper.m_KeyboardMapActionsCallbackInterface != null)
            {
                @EPressAction.started -= m_Wrapper.m_KeyboardMapActionsCallbackInterface.OnEPressAction;
                @EPressAction.performed -= m_Wrapper.m_KeyboardMapActionsCallbackInterface.OnEPressAction;
                @EPressAction.canceled -= m_Wrapper.m_KeyboardMapActionsCallbackInterface.OnEPressAction;
            }
            m_Wrapper.m_KeyboardMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @EPressAction.started += instance.OnEPressAction;
                @EPressAction.performed += instance.OnEPressAction;
                @EPressAction.canceled += instance.OnEPressAction;
            }
        }
    }
    public KeyboardMapActions @KeyboardMap => new KeyboardMapActions(this);

    // InteractionMap
    private readonly InputActionMap m_InteractionMap;
    private IInteractionMapActions m_InteractionMapActionsCallbackInterface;
    private readonly InputAction m_InteractionMap_EscapeButton;
    public struct InteractionMapActions
    {
        private @ControlMap m_Wrapper;
        public InteractionMapActions(@ControlMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @EscapeButton => m_Wrapper.m_InteractionMap_EscapeButton;
        public InputActionMap Get() { return m_Wrapper.m_InteractionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionMapActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionMapActions instance)
        {
            if (m_Wrapper.m_InteractionMapActionsCallbackInterface != null)
            {
                @EscapeButton.started -= m_Wrapper.m_InteractionMapActionsCallbackInterface.OnEscapeButton;
                @EscapeButton.performed -= m_Wrapper.m_InteractionMapActionsCallbackInterface.OnEscapeButton;
                @EscapeButton.canceled -= m_Wrapper.m_InteractionMapActionsCallbackInterface.OnEscapeButton;
            }
            m_Wrapper.m_InteractionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @EscapeButton.started += instance.OnEscapeButton;
                @EscapeButton.performed += instance.OnEscapeButton;
                @EscapeButton.canceled += instance.OnEscapeButton;
            }
        }
    }
    public InteractionMapActions @InteractionMap => new InteractionMapActions(this);
    public interface IMouseMapActions
    {
        void OnRightClickAction(InputAction.CallbackContext context);
        void OnLeftClickAction(InputAction.CallbackContext context);
        void OnMiddleClickAction(InputAction.CallbackContext context);
        void OnMouseMove(InputAction.CallbackContext context);
    }
    public interface IMovimentMapActions
    {
        void OnDirection(InputAction.CallbackContext context);
        void OnDashAction(InputAction.CallbackContext context);
    }
    public interface IKeyboardMapActions
    {
        void OnEPressAction(InputAction.CallbackContext context);
    }
    public interface IInteractionMapActions
    {
        void OnEscapeButton(InputAction.CallbackContext context);
    }
}
