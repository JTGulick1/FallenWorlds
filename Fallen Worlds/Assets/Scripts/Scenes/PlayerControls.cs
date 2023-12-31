//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Scenes/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Mouse+Keyboard"",
            ""id"": ""622cd04f-4551-4998-950f-5643917b482a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d4280ace-0e62-41fc-b393-9f17e43f232e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a582976f-f7bd-45f7-b247-578bfef4f6ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""12612e3c-3201-471e-97f4-99d3a9d95db9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""d7c49cc8-f2dd-4b89-9f04-61d11608d9dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FireWeopon"",
                    ""type"": ""Button"",
                    ""id"": ""6918a3fd-cd73-4ccb-8a32-c73b6a161b06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""a8f31756-510e-46b9-885f-4f3706e005df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""6e3d1a71-9281-44fd-9fe5-8b8e48d9eb02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenInventory"",
                    ""type"": ""Button"",
                    ""id"": ""ace0ed08-77c3-44ec-a490-61bbba9307f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ADS"",
                    ""type"": ""Button"",
                    ""id"": ""edb671a7-6225-43ca-ac2d-5eba656fa0e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LockUnlock"",
                    ""type"": ""Button"",
                    ""id"": ""c9233df6-c670-4b0f-bf85-26f0170b54a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""020f1f84-e78c-4561-9a83-37935f978a76"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9bd4f62-a67b-4944-910e-44a1788960b3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""c0f3abd9-0b82-4b8b-9e17-0d53c4d8902e"",
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
                    ""id"": ""a9aa0a80-5c69-41e9-94d6-8b330483a7ff"",
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
                    ""id"": ""4bc8e92b-557a-4a96-b44d-2f1a96943bbe"",
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
                    ""id"": ""b6ee794e-41bc-431b-bc9b-3853beb41f04"",
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
                    ""id"": ""d7bf9cae-1c14-4693-9452-54c33827b875"",
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
                    ""id"": ""7fb49610-5e97-4b9c-8101-a44ceeac30f5"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28683480-4d79-43ff-a47d-f353cab65c10"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireWeopon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2cc0e80-4ad5-4b72-81c1-1f2f8d2125aa"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a41464b7-2ac8-4b16-8118-3872c94421aa"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""788e5828-93f0-4570-8ac0-0541672226c7"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7df9cd4d-0a7a-402d-b8e5-58571274f9fc"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ADS"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57631860-01ad-4837-9314-6df95670a3a3"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockUnlock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse+Keyboard
        m_MouseKeyboard = asset.FindActionMap("Mouse+Keyboard", throwIfNotFound: true);
        m_MouseKeyboard_Movement = m_MouseKeyboard.FindAction("Movement", throwIfNotFound: true);
        m_MouseKeyboard_Jump = m_MouseKeyboard.FindAction("Jump", throwIfNotFound: true);
        m_MouseKeyboard_Look = m_MouseKeyboard.FindAction("Look", throwIfNotFound: true);
        m_MouseKeyboard_Sprint = m_MouseKeyboard.FindAction("Sprint", throwIfNotFound: true);
        m_MouseKeyboard_FireWeopon = m_MouseKeyboard.FindAction("FireWeopon", throwIfNotFound: true);
        m_MouseKeyboard_Interact = m_MouseKeyboard.FindAction("Interact", throwIfNotFound: true);
        m_MouseKeyboard_Reload = m_MouseKeyboard.FindAction("Reload", throwIfNotFound: true);
        m_MouseKeyboard_OpenInventory = m_MouseKeyboard.FindAction("OpenInventory", throwIfNotFound: true);
        m_MouseKeyboard_ADS = m_MouseKeyboard.FindAction("ADS", throwIfNotFound: true);
        m_MouseKeyboard_LockUnlock = m_MouseKeyboard.FindAction("LockUnlock", throwIfNotFound: true);
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

    // Mouse+Keyboard
    private readonly InputActionMap m_MouseKeyboard;
    private IMouseKeyboardActions m_MouseKeyboardActionsCallbackInterface;
    private readonly InputAction m_MouseKeyboard_Movement;
    private readonly InputAction m_MouseKeyboard_Jump;
    private readonly InputAction m_MouseKeyboard_Look;
    private readonly InputAction m_MouseKeyboard_Sprint;
    private readonly InputAction m_MouseKeyboard_FireWeopon;
    private readonly InputAction m_MouseKeyboard_Interact;
    private readonly InputAction m_MouseKeyboard_Reload;
    private readonly InputAction m_MouseKeyboard_OpenInventory;
    private readonly InputAction m_MouseKeyboard_ADS;
    private readonly InputAction m_MouseKeyboard_LockUnlock;
    public struct MouseKeyboardActions
    {
        private @PlayerControls m_Wrapper;
        public MouseKeyboardActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_MouseKeyboard_Movement;
        public InputAction @Jump => m_Wrapper.m_MouseKeyboard_Jump;
        public InputAction @Look => m_Wrapper.m_MouseKeyboard_Look;
        public InputAction @Sprint => m_Wrapper.m_MouseKeyboard_Sprint;
        public InputAction @FireWeopon => m_Wrapper.m_MouseKeyboard_FireWeopon;
        public InputAction @Interact => m_Wrapper.m_MouseKeyboard_Interact;
        public InputAction @Reload => m_Wrapper.m_MouseKeyboard_Reload;
        public InputAction @OpenInventory => m_Wrapper.m_MouseKeyboard_OpenInventory;
        public InputAction @ADS => m_Wrapper.m_MouseKeyboard_ADS;
        public InputAction @LockUnlock => m_Wrapper.m_MouseKeyboard_LockUnlock;
        public InputActionMap Get() { return m_Wrapper.m_MouseKeyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseKeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IMouseKeyboardActions instance)
        {
            if (m_Wrapper.m_MouseKeyboardActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnLook;
                @Sprint.started -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnSprint;
                @FireWeopon.started -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnFireWeopon;
                @FireWeopon.performed -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnFireWeopon;
                @FireWeopon.canceled -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnFireWeopon;
                @Interact.started -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnInteract;
                @Reload.started -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnReload;
                @OpenInventory.started -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.performed -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.canceled -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnOpenInventory;
                @ADS.started -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnADS;
                @ADS.performed -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnADS;
                @ADS.canceled -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnADS;
                @LockUnlock.started -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnLockUnlock;
                @LockUnlock.performed -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnLockUnlock;
                @LockUnlock.canceled -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnLockUnlock;
            }
            m_Wrapper.m_MouseKeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @FireWeopon.started += instance.OnFireWeopon;
                @FireWeopon.performed += instance.OnFireWeopon;
                @FireWeopon.canceled += instance.OnFireWeopon;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @OpenInventory.started += instance.OnOpenInventory;
                @OpenInventory.performed += instance.OnOpenInventory;
                @OpenInventory.canceled += instance.OnOpenInventory;
                @ADS.started += instance.OnADS;
                @ADS.performed += instance.OnADS;
                @ADS.canceled += instance.OnADS;
                @LockUnlock.started += instance.OnLockUnlock;
                @LockUnlock.performed += instance.OnLockUnlock;
                @LockUnlock.canceled += instance.OnLockUnlock;
            }
        }
    }
    public MouseKeyboardActions @MouseKeyboard => new MouseKeyboardActions(this);
    public interface IMouseKeyboardActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnFireWeopon(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnOpenInventory(InputAction.CallbackContext context);
        void OnADS(InputAction.CallbackContext context);
        void OnLockUnlock(InputAction.CallbackContext context);
    }
}
