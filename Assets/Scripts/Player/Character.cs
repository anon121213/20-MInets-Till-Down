using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Character : MonoBehaviour
{
    [SerializeField] private GameObject _body;
    
    private float _speed = 20f;

    public float Speed
    {
        get { return _speed; }
        set { _speed = Mathf.Clamp(value, 0, float.MaxValue); }
    }
    
    private Rigidbody2D _rb;
    private IInput _IInput;
    private Animator _animator;
    private PlayerStats _playerStats;
    private bool _isDead = false;
    
    private const string speed = nameof(speed);
    private const string die = nameof(die);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = _body.GetComponent<Animator>();
        _IInput = GetComponent<IInput>();
        _playerStats = GetComponent<PlayerStats>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;
    }

    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if (_playerStats.Hp <= 0 && !_isDead)
        {
            _isDead = true;
            _rb.bodyType = RigidbodyType2D.Static;
            _animator.SetTrigger(die);
        }
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
    
    private void OnEnable()
    {
        _IInput.Move += Move;
    }
    
    private void OnDisable()
    {
        _IInput.Move -= Move;
    }
}
