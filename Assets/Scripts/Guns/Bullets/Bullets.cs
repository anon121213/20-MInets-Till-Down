using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullets : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage = 30;
    [SerializeField] private float _speed = 30f;
    
    public int Damage
    {
        get { return _damage; }
        set { _damage = Mathf.Clamp(value, 0, int.MaxValue); }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = Mathf.Clamp(value, 0, float.MaxValue); }
    }
    
    private Rigidbody2D _rb;
    private IDamageble _damageObject;
    private WinSystem _winSystem;
    private GameObject _player;
    
    [Inject]
    private void Inject(WinSystem winSystem, GameObject player)
    {
        _winSystem = winSystem;
        _player = player;
    }
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _speed;
        Invoke(nameof(Destroy), _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<IDamageble>(out IDamageble _damageObject))
        {
            _damageObject.TakeDamage(_damage);
            _winSystem._damageCount += _damage;
        }

        if (collider.gameObject != _player)
        {
            Destroy(gameObject);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
