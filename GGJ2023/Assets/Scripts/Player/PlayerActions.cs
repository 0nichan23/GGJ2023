//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Player/PlayerActions.inputactions
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

public partial class @PlayerActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""BasicActions"",
            ""id"": ""c4525a74-aa7e-4989-9fcb-6f90f8257e61"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""caa97aa9-b82b-4060-a844-f2dda9f32714"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""d43b7a4f-caf6-4531-b441-c4ee311f7c7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""471db94f-8a97-41d4-8c72-c7c3bd46a2b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""fff96a67-f021-4e3f-87db-8de24dd1c115"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1fdcd58c-5d8a-4a94-ba21-df29ec872f56"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f6e4d5f8-0c76-4a62-abb4-33cc1230a239"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""822b3171-610f-4bba-a03e-528ff3b29e01"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7055dfab-87d0-4b06-aa97-ce4d9c10e906"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8f36c4b6-c8f0-4958-84bc-018e0f276f96"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""daa3e8fb-38f3-4b18-8f61-fab3c743c01d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BasicActions
        m_BasicActions = asset.FindActionMap("BasicActions", throwIfNotFound: true);
        m_BasicActions_Movement = m_BasicActions.FindAction("Movement", throwIfNotFound: true);
        m_BasicActions_Attack = m_BasicActions.FindAction("Attack", throwIfNotFound: true);
        m_BasicActions_Jump = m_BasicActions.FindAction("Jump", throwIfNotFound: true);
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

    // BasicActions
    private readonly InputActionMap m_BasicActions;
    private IBasicActionsActions m_BasicActionsActionsCallbackInterface;
    private readonly InputAction m_BasicActions_Movement;
    private readonly InputAction m_BasicActions_Attack;
    private readonly InputAction m_BasicActions_Jump;
    public struct BasicActionsActions
    {
        private @PlayerActions m_Wrapper;
        public BasicActionsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_BasicActions_Movement;
        public InputAction @Attack => m_Wrapper.m_BasicActions_Attack;
        public InputAction @Jump => m_Wrapper.m_BasicActions_Jump;
        public InputActionMap Get() { return m_Wrapper.m_BasicActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicActionsActions set) { return set.Get(); }
        public void SetCallbacks(IBasicActionsActions instance)
        {
            if (m_Wrapper.m_BasicActionsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_BasicActionsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_BasicActionsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_BasicActionsActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_BasicActionsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_BasicActionsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_BasicActionsActionsCallbackInterface.OnAttack;
                @Jump.started -= m_Wrapper.m_BasicActionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BasicActionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BasicActionsActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_BasicActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public BasicActionsActions @BasicActions => new BasicActionsActions(this);
    public interface IBasicActionsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
