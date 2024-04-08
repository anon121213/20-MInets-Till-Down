using System;
using Unity.VisualScripting;
using UnityEngine;

public class MachineGuns : MonoBehaviour
{
    [SerializeField] private GameObject _input;
    [SerializeField] private GameObject _bullet;

    private IInput _iInput;
    
    private void Awake()
    {
        _iInput = _input.GetComponent<IInput>();
    }

    private void OnEnable()
    {
        _iInput.IsShootting += IsShoottingPc;
        _iInput.ShootingJoy += IsShoottingMobile;
    }
    
    private void OnDisable()
    {
        _iInput.IsShootting -= IsShoottingPc;
        _iInput.ShootingJoy -= IsShoottingMobile;
    }

    private void IsShoottingPc(bool _isShoot)
    {
        if (_isShoot)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
            Debug.Log("sfaf");
        }
    }

    private void IsShoottingMobile(Vector2 _ShootVector)
    {
        if (_ShootVector != new Vector2(0f, 0f))
        {
            Instantiate(_bullet, transform.position, transform.rotation);
            Debug.Log("aasfasf");
        }
    }
}
