using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterMovement),typeof(PlayerInput))]
public class PlayerControls : MonoBehaviour
{
    [HideInInspector] public CharacterMovement _charMovement;
    [HideInInspector] public DialogueActor _playerActor;
    [HideInInspector] public PlayerInput _playerInput;
    [HideInInspector] public InputAction _moveAction;
    [HideInInspector] public InputAction _jumpAction;
    [HideInInspector] public InputAction _interactAction;
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private FightTower _tower;
    public static EventSystem eventSystem
    {
        get { return Instance._eventSystem; }
    }

    public static PlayerControls Instance;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _charMovement = GetComponent<CharacterMovement>();
        _playerActor = GetComponent<DialogueActor>();
        _moveAction = _playerInput.actions.FindAction("MoveAction");
        _jumpAction = _playerInput.actions.FindAction("JumpAction");
        //_jumpAction.performed += _charMovement.Jump;
        _interactAction = _playerInput.actions.FindAction("InteractAction");
        _interactAction.started += _playerActor.Interact;
        _interactAction.started += _tower.Interact;
    }

    private void FixedUpdate()
    {
        _charMovement.Move(_moveAction.ReadValue<Vector2>());
    }

    public static void SwitchToMovementInputs()
    {
        Instance._playerInput.SwitchCurrentActionMap("Movement");
    }
    public static void SwitchToUIInputs()
    {
        Instance._playerInput.SwitchCurrentActionMap("UI");
    }
    public void SwitchToCombatInputs()
    {
        Instance._playerInput.SwitchCurrentActionMap("Combat");
        
    }
    
}
