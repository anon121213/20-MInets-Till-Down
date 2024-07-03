using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class EnemyDamage : MonoBehaviour, IDamageble
{
    [SerializeField] private int _hp = 100;
    [SerializeField] private int _getDamage;
    [SerializeField] private int _takeDamage;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _drag = 1.5f;
    [SerializeField] private GameObject _xp;
    
    private Transform _emptyXp;
    private GameObject _player;
    private WinSystem _winSystem;
    private Rigidbody2D _rb;
    
    public Transform EmptyXp
    {
        get => _emptyXp;
        set
        {
            if (value is Transform) _emptyXp = value;
        } 
    }

    [Inject] private DiContainer _diContainer;
    [Inject] public void GetPlayer(GameObject player, WinSystem winSystem)
    {
        _player = player;
        _winSystem = winSystem;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Character>())
        {
            TakeDamageToPlayer();
        }
    }

    public void GetDamageToEnemy(int _damage)
    {
        _hp -= _damage;
        
        if (_hp <= 0)
        {
            _diContainer.InstantiatePrefab(_xp, transform.position, quaternion.identity, _emptyXp);
            _winSystem._kills += 1;
            Destroy(gameObject);
        }
    }
    
    private void TakeDamageToPlayer()
    {
        var pushDirection = -(transform.position - _player.transform.position).normalized;
            
        _rb.AddForce(-pushDirection * _pushForce * 1000, ForceMode2D.Impulse);
        _rb.drag = _drag;
        
        var Character = _player.GetComponent<Character>();
        Character.GetDamage(_takeDamage);
    }
}
