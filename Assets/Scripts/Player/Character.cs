using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Character : MonoBehaviour
{
    public event Action<int> DamageTaken;
    
    [SerializeField] private GameObject _body;
    
    private float _speed = 20f;
    private bool _isDead = false;
    
    private Rigidbody2D _rb;
    private IInput[] _IInput;
    private Animator _animator;
    private PlayerStats _playerStats;
    private IDamageble _damagebleImplementation;

    private const string speed = nameof(speed);
    private const string die = nameof(die);
    
    public float Speed
    {
        get { return _speed; }
        set { _speed = Mathf.Clamp(value, 0, float.MaxValue); }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = _body.GetComponent<Animator>();
        _IInput = GetComponents<IInput>();
        _playerStats = GetComponent<PlayerStats>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 240;
    }
    
    private void Move(Vector2 direction)
    {
        if (!_isDead)
        {
            _rb.velocity = direction * _speed;
            _animator.SetFloat(speed, Mathf.Abs(direction.x) + Mathf.Abs(direction.y));

            if (direction.x < 0)
            {
                _body.transform.localScale = new Vector2(-1f, 1f);
            }
            else if (direction.x > 0)
            {
                _body.transform.localScale = new Vector2(1f, 1f);
            }
        }
    }
    
    public void GetDamage(int Damage)
    {
        if (_playerStats.Hp > 1 && !_isDead)
        {
            _playerStats.Hp -= Damage;
            DamageTaken?.Invoke(Damage);
        }
        else
        {
            if (!_isDead)
            {
                _isDead = true;
                _rb.bodyType = RigidbodyType2D.Static;
                _animator.SetTrigger(die);
                DamageTaken?.Invoke(Damage);
            }
        }
    }
    
    private void OnEnable()
    {
        _IInput[0].Move += Move;
        _IInput[1].Move += Move;
    }
    
    private void OnDisable()
    {
        _IInput[0].Move -= Move;
        _IInput[1].Move -= Move;
    }
}

