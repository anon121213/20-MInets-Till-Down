using System.Collections;
using UnityEngine;
using Zenject;

public class Gun : MonoBehaviour
{
    #region fields
    [Space] [InspectorName("Game objects")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private Animator _pistolAnimator;
    
    [Space] [InspectorName("Gun properties")]
    [SerializeField] private float _shootSpeed;
    [SerializeField] private float _reloadDelay;
    [SerializeField] private int _ammo;
    
    [Space] [InspectorName("Camera Shake properties")]
    [SerializeField] private float _cameraShakeAmplitude;
    [SerializeField] private float _cameraShakeFrequency;
    [SerializeField] private float _cameraShakeDuration;
    #endregion
    
    private const string _reload = nameof(Reload);
    
    public float ShootSpeed
    {
        get { return _shootSpeed; }
        set { _shootSpeed = Mathf.Clamp(value, 0, float.MaxValue); }
    }
    
    public int Ammo
    {
        get { return _ammo; }
        set { _ammo = Mathf.Clamp(value, 0, int.MaxValue); }
    }
    
    public float ReloadDelay
    {
        get { return _reloadDelay; }
        set { _reloadDelay = Mathf.Clamp(value, 0, float.MaxValue); }
    }
    
    private IInput _iInput;
    private bool _canShoot = true;
    private int _ammoCount;
    
    [Inject] private DiContainer _diContainer;
    
    private void Awake()
    {
        _iInput = _player.GetComponent<IInput>();
        _ammoCount = Ammo;
    }
    
    private void IsShoottingPc()
    {
        if (_canShoot)
        {
            if (Ammo > 0)
            {
                StartCoroutine(ShootDelay(ShootSpeed));
            }
            else
            {
                StartCoroutine(Reload(ReloadDelay));
            }
        }
    }

    private void IsShoottingMobile(Vector2 _shootVector)
    {
        if (_shootVector != new Vector2(0f, 0f) && _canShoot)
        {
            if (Ammo > 0)
            {
                StartCoroutine(ShootDelay(ShootSpeed));
            }
            else
            {
                StartCoroutine(Reload(ReloadDelay));
            }
        }
    }

    private IEnumerator ShootDelay(float delayTime)
    {
        Ammo--;
        _canShoot = false;
        CameraShake.Instanse.ShakeCamera(_cameraShakeAmplitude, _cameraShakeFrequency, _cameraShakeDuration);
        _diContainer.InstantiatePrefab(_bullet, _shootPoint.transform.position, transform.rotation, transform.parent);
        yield return new WaitForSeconds(delayTime);
        _canShoot = true;
    }

    private IEnumerator Reload(float reloadDelay)
    {
        _pistolAnimator.SetBool(nameof(Reload), true);
        _canShoot = false;
        yield return new WaitForSeconds(reloadDelay);
        Ammo = _ammoCount;
        _canShoot = true;
        _pistolAnimator.SetBool(nameof(Reload), false);
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
}
