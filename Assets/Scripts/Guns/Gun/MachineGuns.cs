using System;
using System.Collections;
using UnityEngine;

public class MachineGuns : MonoBehaviour
{
    [SerializeField] private GameObject _input;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private float _DelayTime;
    [SerializeField] private int _ammo;
    [SerializeField] private float _reloadDelay;

    private IInput _iInput;
    private bool _canShoot = true;
    private int _ammoCount;
    
    private void Awake()
    {
        _iInput = _input.GetComponent<IInput>();
        _ammoCount = _ammo;
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

    private void IsShoottingPc()
    {
        if (_canShoot)
        {
            if (_ammo > 0)
            {
                StartCoroutine(ShootDelay(_DelayTime));
            }
            else
            {
                StartCoroutine(Reload(_reloadDelay));
            }
        }
    }

    private void IsShoottingMobile(Vector2 _ShootVector)
    {
        if (_ShootVector != new Vector2(0f, 0f))
        {
            if (_ammo > 0)
            {
                StartCoroutine(ShootDelay(_DelayTime));
            }
            else
            {
                StartCoroutine(Reload(_reloadDelay));
            }
        }
    }

    private IEnumerator ShootDelay(float delayTime)
    {
        _ammo--;
        _canShoot = false;
        Instantiate(_bullet, _shootPoint.transform.position, transform.rotation);
        yield return new WaitForSeconds(delayTime);
        _canShoot = true;
    }

    private IEnumerator Reload(float reloadDelay)
    {
        _canShoot = false;
        yield return new WaitForSeconds(reloadDelay);
        _ammo = _ammoCount;
        _canShoot = true;
    }
}
