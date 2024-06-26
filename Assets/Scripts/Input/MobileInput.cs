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

    private GameObject _player;
    
    [Inject]
    private void Inject(GameObject player)
    {
        _player = player;
    }

    private void Awake()
    {
        _Joystick = _player.GetComponent<Character>()._MoveJoy;
        _ShootJoystick = _player.GetComponent<Character>()._ShootJoy;
        print(_Joystick);
        print(_ShootJoystick);
    }

    private void GetInputDirection()
    {
        var _direction = new Vector2(_Joystick.Horizontal, _Joystick.Vertical).normalized;
        if (_direction != Vector2.zero) { Move?.Invoke(_direction); }
    }

    private void Shoot()
    {
        var _direction = new Vector2(-_ShootJoystick.Horizontal, _ShootJoystick.Vertical).normalized;
        if (_direction != Vector2.zero) { ShootingJoy?.Invoke(_direction); }
    }
    
    private void Update()
    {
        GetInputDirection();
        Shoot();
    }
}
