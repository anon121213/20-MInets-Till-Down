using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullets : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    
    private Rigidbody2D _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _speed;
        Invoke(nameof(Destroy), _lifeTime);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
