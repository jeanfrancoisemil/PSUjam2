//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Remi/Input/Player.inputactions
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

public partial class @Player: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""main"",
            ""id"": ""ad196335-1ea3-4839-9dd8-566f2fa0aafe"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""da0c3af9-df87-42d4-9390-304c88ac7484"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""160651b5-f7d8-43ea-b79e-24d1585f6715"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""7d42663e-20de-4f70-bd45-b970dc74bc20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""b0fc909a-9e1b-44b6-86d8-c7e5aca2cdc0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""ab21e3f9-7ae9-4184-a6c0-5566535a3b8d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""58158d22-b729-4dcc-b01a-791285e5ed66"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8d8457f6-0552-445f-a3b7-69df977d8626"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f9d48e7c-4b81-4682-826b-5a08e685ad46"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bab511ca-34e7-4644-9d2f-e2a17555b29a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47bc3e12-4a8b-4afe-9d28-bac11d0e3878"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ArmeVerticale"",
            ""id"": ""254eb956-ab4a-4ab4-9349-0daf12f2451d"",
            ""actions"": [
                {
                    ""name"": ""ShootUp"",
                    ""type"": ""Value"",
                    ""id"": ""9f4c476a-f9c9-4a5f-9589-ad9cb56d4617"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Vertical"",
                    ""id"": ""68a6fe0e-f065-4fe8-9a9f-c7fc3b80a9df"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootUp"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""fe74035a-9488-49ad-aeb9-803f7179c43e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""df2e461b-2d7a-4b59-8a17-a9cc6e2eb616"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""ArmeHorizontale"",
            ""id"": ""52f280a7-6d8f-4c62-9fdd-7f39fde25d32"",
            ""actions"": [
                {
                    ""name"": ""ShootRight"",
                    ""type"": ""Value"",
                    ""id"": ""169bfebc-a089-410a-8e7c-5b566df3f29b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""095fdadc-f26c-45cb-bbbb-067fa2ddbd12"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""610b573e-87fd-4876-9e1f-32c2617f8c08"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f1c9b6b2-d8c5-4490-bc60-1b99d9bda40a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""ArmeZone"",
            ""id"": ""783f1cb3-9379-4980-9f0c-0d2afd275b1c"",
            ""actions"": [
                {
                    ""name"": ""ShootDir"",
                    ""type"": ""Value"",
                    ""id"": ""449dfede-04b9-41ae-83b6-39cc894969d8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Dirrection"",
                    ""id"": ""d4d582da-999f-4b74-be57-bf90e6363592"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootDir"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cc42dbd5-67fb-4a8a-82e6-e8f6d7339531"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c2a4130a-f943-4192-8d5a-adb53f0911fd"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7fdadb0f-8d64-4f32-bf66-5c922deef90f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""86d370b9-bc58-42bb-838a-04ea0036e63f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""SwitchArme"",
            ""id"": ""138a7b30-ac9a-4d95-b617-cd453db1c9a1"",
            ""actions"": [
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""b2835f4f-006c-4918-8810-f6186110cec1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""17e043d6-8f02-44ab-ac84-a28d1b170582"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""6fcaad33-f079-4ad5-a770-4b3d7c5f11bf"",
            ""actions"": [
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Button"",
                    ""id"": ""02213e52-0b2d-41fb-8958-299a45db14f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fa3ce9b0-b36b-450e-86e5-336c924606ed"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""WavePause"",
            ""id"": ""ae421471-5711-463c-8720-7bb773b79490"",
            ""actions"": [
                {
                    ""name"": ""LeftButton"",
                    ""type"": ""Button"",
                    ""id"": ""5a9358dd-7650-4957-aec9-906f11d01d24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightButton"",
                    ""type"": ""Button"",
                    ""id"": ""25417ce3-f669-4c3f-ab03-d2efc70d2188"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bfd737e3-41c8-4239-9915-eb32cc77743c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a1c656e-4b41-4183-bba3-338e72c5edb8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // main
        m_main = asset.FindActionMap("main", throwIfNotFound: true);
        m_main_Move = m_main.FindAction("Move", throwIfNotFound: true);
        m_main_Jump = m_main.FindAction("Jump", throwIfNotFound: true);
        m_main_Down = m_main.FindAction("Down", throwIfNotFound: true);
        m_main_Dash = m_main.FindAction("Dash", throwIfNotFound: true);
        // ArmeVerticale
        m_ArmeVerticale = asset.FindActionMap("ArmeVerticale", throwIfNotFound: true);
        m_ArmeVerticale_ShootUp = m_ArmeVerticale.FindAction("ShootUp", throwIfNotFound: true);
        // ArmeHorizontale
        m_ArmeHorizontale = asset.FindActionMap("ArmeHorizontale", throwIfNotFound: true);
        m_ArmeHorizontale_ShootRight = m_ArmeHorizontale.FindAction("ShootRight", throwIfNotFound: true);
        // ArmeZone
        m_ArmeZone = asset.FindActionMap("ArmeZone", throwIfNotFound: true);
        m_ArmeZone_ShootDir = m_ArmeZone.FindAction("ShootDir", throwIfNotFound: true);
        // SwitchArme
        m_SwitchArme = asset.FindActionMap("SwitchArme", throwIfNotFound: true);
        m_SwitchArme_Switch = m_SwitchArme.FindAction("Switch", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Scroll = m_Camera.FindAction("Scroll", throwIfNotFound: true);
        // WavePause
        m_WavePause = asset.FindActionMap("WavePause", throwIfNotFound: true);
        m_WavePause_LeftButton = m_WavePause.FindAction("LeftButton", throwIfNotFound: true);
        m_WavePause_RightButton = m_WavePause.FindAction("RightButton", throwIfNotFound: true);
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

    // main
    private readonly InputActionMap m_main;
    private List<IMainActions> m_MainActionsCallbackInterfaces = new List<IMainActions>();
    private readonly InputAction m_main_Move;
    private readonly InputAction m_main_Jump;
    private readonly InputAction m_main_Down;
    private readonly InputAction m_main_Dash;
    public struct MainActions
    {
        private @Player m_Wrapper;
        public MainActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_main_Move;
        public InputAction @Jump => m_Wrapper.m_main_Jump;
        public InputAction @Down => m_Wrapper.m_main_Down;
        public InputAction @Dash => m_Wrapper.m_main_Dash;
        public InputActionMap Get() { return m_Wrapper.m_main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void AddCallbacks(IMainActions instance)
        {
            if (instance == null || m_Wrapper.m_MainActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MainActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Down.started += instance.OnDown;
            @Down.performed += instance.OnDown;
            @Down.canceled += instance.OnDown;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
        }

        private void UnregisterCallbacks(IMainActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Down.started -= instance.OnDown;
            @Down.performed -= instance.OnDown;
            @Down.canceled -= instance.OnDown;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
        }

        public void RemoveCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMainActions instance)
        {
            foreach (var item in m_Wrapper.m_MainActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MainActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MainActions @main => new MainActions(this);

    // ArmeVerticale
    private readonly InputActionMap m_ArmeVerticale;
    private List<IArmeVerticaleActions> m_ArmeVerticaleActionsCallbackInterfaces = new List<IArmeVerticaleActions>();
    private readonly InputAction m_ArmeVerticale_ShootUp;
    public struct ArmeVerticaleActions
    {
        private @Player m_Wrapper;
        public ArmeVerticaleActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @ShootUp => m_Wrapper.m_ArmeVerticale_ShootUp;
        public InputActionMap Get() { return m_Wrapper.m_ArmeVerticale; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ArmeVerticaleActions set) { return set.Get(); }
        public void AddCallbacks(IArmeVerticaleActions instance)
        {
            if (instance == null || m_Wrapper.m_ArmeVerticaleActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ArmeVerticaleActionsCallbackInterfaces.Add(instance);
            @ShootUp.started += instance.OnShootUp;
            @ShootUp.performed += instance.OnShootUp;
            @ShootUp.canceled += instance.OnShootUp;
        }

        private void UnregisterCallbacks(IArmeVerticaleActions instance)
        {
            @ShootUp.started -= instance.OnShootUp;
            @ShootUp.performed -= instance.OnShootUp;
            @ShootUp.canceled -= instance.OnShootUp;
        }

        public void RemoveCallbacks(IArmeVerticaleActions instance)
        {
            if (m_Wrapper.m_ArmeVerticaleActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IArmeVerticaleActions instance)
        {
            foreach (var item in m_Wrapper.m_ArmeVerticaleActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ArmeVerticaleActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ArmeVerticaleActions @ArmeVerticale => new ArmeVerticaleActions(this);

    // ArmeHorizontale
    private readonly InputActionMap m_ArmeHorizontale;
    private List<IArmeHorizontaleActions> m_ArmeHorizontaleActionsCallbackInterfaces = new List<IArmeHorizontaleActions>();
    private readonly InputAction m_ArmeHorizontale_ShootRight;
    public struct ArmeHorizontaleActions
    {
        private @Player m_Wrapper;
        public ArmeHorizontaleActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @ShootRight => m_Wrapper.m_ArmeHorizontale_ShootRight;
        public InputActionMap Get() { return m_Wrapper.m_ArmeHorizontale; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ArmeHorizontaleActions set) { return set.Get(); }
        public void AddCallbacks(IArmeHorizontaleActions instance)
        {
            if (instance == null || m_Wrapper.m_ArmeHorizontaleActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ArmeHorizontaleActionsCallbackInterfaces.Add(instance);
            @ShootRight.started += instance.OnShootRight;
            @ShootRight.performed += instance.OnShootRight;
            @ShootRight.canceled += instance.OnShootRight;
        }

        private void UnregisterCallbacks(IArmeHorizontaleActions instance)
        {
            @ShootRight.started -= instance.OnShootRight;
            @ShootRight.performed -= instance.OnShootRight;
            @ShootRight.canceled -= instance.OnShootRight;
        }

        public void RemoveCallbacks(IArmeHorizontaleActions instance)
        {
            if (m_Wrapper.m_ArmeHorizontaleActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IArmeHorizontaleActions instance)
        {
            foreach (var item in m_Wrapper.m_ArmeHorizontaleActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ArmeHorizontaleActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ArmeHorizontaleActions @ArmeHorizontale => new ArmeHorizontaleActions(this);

    // ArmeZone
    private readonly InputActionMap m_ArmeZone;
    private List<IArmeZoneActions> m_ArmeZoneActionsCallbackInterfaces = new List<IArmeZoneActions>();
    private readonly InputAction m_ArmeZone_ShootDir;
    public struct ArmeZoneActions
    {
        private @Player m_Wrapper;
        public ArmeZoneActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @ShootDir => m_Wrapper.m_ArmeZone_ShootDir;
        public InputActionMap Get() { return m_Wrapper.m_ArmeZone; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ArmeZoneActions set) { return set.Get(); }
        public void AddCallbacks(IArmeZoneActions instance)
        {
            if (instance == null || m_Wrapper.m_ArmeZoneActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ArmeZoneActionsCallbackInterfaces.Add(instance);
            @ShootDir.started += instance.OnShootDir;
            @ShootDir.performed += instance.OnShootDir;
            @ShootDir.canceled += instance.OnShootDir;
        }

        private void UnregisterCallbacks(IArmeZoneActions instance)
        {
            @ShootDir.started -= instance.OnShootDir;
            @ShootDir.performed -= instance.OnShootDir;
            @ShootDir.canceled -= instance.OnShootDir;
        }

        public void RemoveCallbacks(IArmeZoneActions instance)
        {
            if (m_Wrapper.m_ArmeZoneActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IArmeZoneActions instance)
        {
            foreach (var item in m_Wrapper.m_ArmeZoneActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ArmeZoneActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ArmeZoneActions @ArmeZone => new ArmeZoneActions(this);

    // SwitchArme
    private readonly InputActionMap m_SwitchArme;
    private List<ISwitchArmeActions> m_SwitchArmeActionsCallbackInterfaces = new List<ISwitchArmeActions>();
    private readonly InputAction m_SwitchArme_Switch;
    public struct SwitchArmeActions
    {
        private @Player m_Wrapper;
        public SwitchArmeActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Switch => m_Wrapper.m_SwitchArme_Switch;
        public InputActionMap Get() { return m_Wrapper.m_SwitchArme; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SwitchArmeActions set) { return set.Get(); }
        public void AddCallbacks(ISwitchArmeActions instance)
        {
            if (instance == null || m_Wrapper.m_SwitchArmeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SwitchArmeActionsCallbackInterfaces.Add(instance);
            @Switch.started += instance.OnSwitch;
            @Switch.performed += instance.OnSwitch;
            @Switch.canceled += instance.OnSwitch;
        }

        private void UnregisterCallbacks(ISwitchArmeActions instance)
        {
            @Switch.started -= instance.OnSwitch;
            @Switch.performed -= instance.OnSwitch;
            @Switch.canceled -= instance.OnSwitch;
        }

        public void RemoveCallbacks(ISwitchArmeActions instance)
        {
            if (m_Wrapper.m_SwitchArmeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISwitchArmeActions instance)
        {
            foreach (var item in m_Wrapper.m_SwitchArmeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SwitchArmeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SwitchArmeActions @SwitchArme => new SwitchArmeActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private List<ICameraActions> m_CameraActionsCallbackInterfaces = new List<ICameraActions>();
    private readonly InputAction m_Camera_Scroll;
    public struct CameraActions
    {
        private @Player m_Wrapper;
        public CameraActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Scroll => m_Wrapper.m_Camera_Scroll;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void AddCallbacks(ICameraActions instance)
        {
            if (instance == null || m_Wrapper.m_CameraActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CameraActionsCallbackInterfaces.Add(instance);
            @Scroll.started += instance.OnScroll;
            @Scroll.performed += instance.OnScroll;
            @Scroll.canceled += instance.OnScroll;
        }

        private void UnregisterCallbacks(ICameraActions instance)
        {
            @Scroll.started -= instance.OnScroll;
            @Scroll.performed -= instance.OnScroll;
            @Scroll.canceled -= instance.OnScroll;
        }

        public void RemoveCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICameraActions instance)
        {
            foreach (var item in m_Wrapper.m_CameraActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CameraActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // WavePause
    private readonly InputActionMap m_WavePause;
    private List<IWavePauseActions> m_WavePauseActionsCallbackInterfaces = new List<IWavePauseActions>();
    private readonly InputAction m_WavePause_LeftButton;
    private readonly InputAction m_WavePause_RightButton;
    public struct WavePauseActions
    {
        private @Player m_Wrapper;
        public WavePauseActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftButton => m_Wrapper.m_WavePause_LeftButton;
        public InputAction @RightButton => m_Wrapper.m_WavePause_RightButton;
        public InputActionMap Get() { return m_Wrapper.m_WavePause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WavePauseActions set) { return set.Get(); }
        public void AddCallbacks(IWavePauseActions instance)
        {
            if (instance == null || m_Wrapper.m_WavePauseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WavePauseActionsCallbackInterfaces.Add(instance);
            @LeftButton.started += instance.OnLeftButton;
            @LeftButton.performed += instance.OnLeftButton;
            @LeftButton.canceled += instance.OnLeftButton;
            @RightButton.started += instance.OnRightButton;
            @RightButton.performed += instance.OnRightButton;
            @RightButton.canceled += instance.OnRightButton;
        }

        private void UnregisterCallbacks(IWavePauseActions instance)
        {
            @LeftButton.started -= instance.OnLeftButton;
            @LeftButton.performed -= instance.OnLeftButton;
            @LeftButton.canceled -= instance.OnLeftButton;
            @RightButton.started -= instance.OnRightButton;
            @RightButton.performed -= instance.OnRightButton;
            @RightButton.canceled -= instance.OnRightButton;
        }

        public void RemoveCallbacks(IWavePauseActions instance)
        {
            if (m_Wrapper.m_WavePauseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWavePauseActions instance)
        {
            foreach (var item in m_Wrapper.m_WavePauseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WavePauseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WavePauseActions @WavePause => new WavePauseActions(this);
    public interface IMainActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IArmeVerticaleActions
    {
        void OnShootUp(InputAction.CallbackContext context);
    }
    public interface IArmeHorizontaleActions
    {
        void OnShootRight(InputAction.CallbackContext context);
    }
    public interface IArmeZoneActions
    {
        void OnShootDir(InputAction.CallbackContext context);
    }
    public interface ISwitchArmeActions
    {
        void OnSwitch(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnScroll(InputAction.CallbackContext context);
    }
    public interface IWavePauseActions
    {
        void OnLeftButton(InputAction.CallbackContext context);
        void OnRightButton(InputAction.CallbackContext context);
    }
}
