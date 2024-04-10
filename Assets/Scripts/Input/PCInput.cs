using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCInput : MonoBehaviour, IInput
{
    public event Action<Vector2> Move;
    public event Action<bool> IsShootting;
    public event Action<Vector2> ShootingJoy;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    private void GetInputDirection()
    {
        var _direction = _playerInput.Pc.Movement.ReadValue<Vector2>();
        Move?.Invoke(_direction.normalized);
    }
    
    private void OnEnable()
    {
        _playerInput.Pc.Shooting.performed += ShootPerformed;
        _playerInput.Pc.Shooting.canceled += NotShootPerformed;
    }
    
    private void OnDisable()
    {
        _playerInput.Pc.Shooting.performed -= ShootPerformed;
        _playerInput.Pc.Shooting.canceled -= NotShootPerformed;
    }

    private void ShootPerformed(InputAction.CallbackContext obj)
    {
        IsShootting?.Invoke(true);
    }
    
    private void NotShootPerformed(InputAction.CallbackContext obj)
    {
        IsShootting?.Invoke(false);
    }
    
    private void Update()
    {
        GetInputDirection();
    }
}
