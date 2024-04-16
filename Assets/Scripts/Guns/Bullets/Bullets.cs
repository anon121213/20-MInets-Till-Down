using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullets : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;
    
    private Rigidbody2D _rb;
    private IDamageble _damageObject;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _speed;
        Invoke(nameof(Destroy), _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D _collider)
    {
        _damageObject = _collider.gameObject.GetComponent<IDamageble>();
        _damageObject.TakeDamage(_damage);
        
        Destroy(gameObject);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
