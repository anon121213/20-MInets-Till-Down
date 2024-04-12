using System;
using UnityEngine;

public class PCInput : MonoBehaviour, IInput
{
    public event Action<Vector2> Move;
    public event Action IsShootting;
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
   
    private void Update()
    {
        GetInputDirection();
        
        if (_playerInput.Pc.Shooting.ReadValue<float>() > 0)
        {
            IsShootting?.Invoke();
        }
    }
}
