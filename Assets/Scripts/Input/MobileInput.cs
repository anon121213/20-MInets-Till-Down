using System;
using UnityEngine;
using Zenject;

public class MobileInput : MonoBehaviour, IInput
{
    public event Action<Vector2> Move;
    public event Action<bool> IsShootting;
    public event Action<Vector2> ShootingJoy;

    [SerializeField] private Joystick _Joystick;
    [SerializeField] private Joystick _ShootJoystick;

    private void GetInputDirection()
    {
        var _direction = new Vector2(_Joystick.Horizontal, _Joystick.Vertical).normalized;
        Move?.Invoke(_direction);
    }

    private void Shoot()
    {
        var _direction = new Vector2(-_ShootJoystick.Horizontal, _ShootJoystick.Vertical).normalized;
        ShootingJoy?.Invoke(_direction);
    }
    
    private void Update()
    {
        GetInputDirection();
        Shoot();
    }
}
