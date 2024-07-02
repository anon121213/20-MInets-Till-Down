using System;
using UnityEngine;
using Zenject;

public class MobileInput : MonoBehaviour, IInput
{
    public event Action<Vector2> Move;
    public event Action IsShootting;
    public event Action<Vector2> ShootingJoy;

    [SerializeField] private Joystick _Joystick;
    [SerializeField] private Joystick _ShootJoystick;

    private Character _player;

    private void GetInputDirection()
    {
        if (_Joystick)
        {
            var _direction = new Vector2(_Joystick.Horizontal, _Joystick.Vertical).normalized;
            if (_direction != Vector2.zero) { Move?.Invoke(_direction); }
        }
        else
        {
            throw new Exception("Move Joystick is Null");
        }
    }

    private void Shoot()
    {
        if (_ShootJoystick)
        {
            var _direction = new Vector2(-_ShootJoystick.Horizontal, _ShootJoystick.Vertical).normalized;
            if (_direction != Vector2.zero) { ShootingJoy?.Invoke(_direction); }
        }
        else
        {
            throw new Exception("Shoot Joystick is Null");
        }
    }
    
    private void Update()
    {
        GetInputDirection();
        Shoot();
    }
}
