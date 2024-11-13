using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterMovement),typeof(PlayerInput))]
public class PlayerControls : MonoBehaviour
{
    private CharacterMovement _charMovement;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _interactAction;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _charMovement = GetComponent<CharacterMovement>();
        _moveAction = _playerInput.actions.FindAction("MoveAction");
        _jumpAction = _playerInput.actions.FindAction("JumpAction");
        //_jumpAction.performed += _charMovement.Jump;
        _interactAction = _playerInput.actions.FindAction("InteractAction");
    }

    private void FixedUpdate()
    {
        _charMovement.Move(_moveAction.ReadValue<Vector2>());
    }
}
