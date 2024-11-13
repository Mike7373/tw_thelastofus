using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _jumpIntensity;
    [SerializeField] private GameObject _playerModel;
    private Rigidbody _rb;
    private Vector2 _charDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 direction)
    {
        //_playerModel.transform.LookAt(new Vector2(transform.position.x + direction.x,transform.position.z + direction.z ));
        // _rb.position += direction * (Time.deltaTime * _speed);
        _rb.linearVelocity = new Vector3(direction.x, 0, direction.y) * _speed;
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            _playerModel.transform.rotation = Quaternion.Euler(-90, angle, 0);
        }
    }

    // public void Jump(InputAction.CallbackContext callbackContext)
    // {
    //     _rb.AddForce(Vector3.up * _jumpIntensity);
    //     Debug.Log("JUMP!");
    // }
}
