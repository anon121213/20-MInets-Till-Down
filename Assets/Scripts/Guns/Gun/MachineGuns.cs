using System.Collections;
using UnityEngine;

public class MachineGuns : MonoBehaviour
{
    [SerializeField] private GameObject _input;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private float _DelayTime;

    private IInput _iInput;
    private bool _isShooting = false;
    
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
        if (_isShoot && !_isShooting)
        {
            StartCoroutine(ShootDelay(_DelayTime));
        }
    }

    private void IsShoottingMobile(Vector2 _ShootVector)
    {
        if (_ShootVector != new Vector2(0f, 0f))
        {
            StartCoroutine(ShootDelay(_DelayTime));
        }
    }

    private IEnumerator ShootDelay(float _DelayTime)
    {
        _isShooting = true;
        Instantiate(_bullet, _shootPoint.transform.position, transform.rotation);
        yield return new WaitForSeconds(_DelayTime);
        _isShooting = false;
    }
}
