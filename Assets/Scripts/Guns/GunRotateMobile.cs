using System;
using UnityEngine;

public class GunRotateMobile : MonoBehaviour
{
    [SerializeField] Transform _centralObject;
    
    private IInput _IInput;

    private void Awake()
    {
        _IInput = GetComponent<IInput>();
    }

    private void OnEnable()
    {
        _IInput.ShootingJoy += GunRotaiter;
    }
    
    private void OnDisable()
    {
        _IInput.ShootingJoy -= GunRotaiter;
    }

    private void GunRotaiter(Vector2 _RotateDirection)
    {
        
    }
}
