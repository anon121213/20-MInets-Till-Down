using System;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class EnemyDamage : MonoBehaviour, IDamageble
{
    [SerializeField] private int _takeDamage;
    [SerializeField] private float _pushForce;
    [SerializeField] private GameObject _xp;
    [SerializeField] private int Hp = 100;
    [SerializeField] private float drag = 1.5f;
    
    [NonSerialized] public Transform _emptyXp;
    
    private GameObject _player;
    private WinSystem _winSystem;
    private Rigidbody2D _rb;
    
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
            GetDamage(_takeDamage);
        }
    }

    public void TakeDamage(int _damage)
    {
        Hp -= _damage;
        
        if (Hp <= 0)
        {
            _diContainer.InstantiatePrefab(_xp, transform.position, quaternion.identity, _emptyXp);
            _winSystem._kills += 1;
            Destroy(gameObject);
        }
    }

    public void GetDamage(int _getDamage)
    {
        var _playerHp = _player.gameObject.GetComponent<PlayerStats>().Hp;

        if (_playerHp > 0)
        {
            var pushDirection = -(transform.position - _player.transform.position).normalized;
            
            _rb.AddForce(-pushDirection * _pushForce * 1000, ForceMode2D.Impulse);
            _rb.drag = drag;

            var playerHp = _player.gameObject.GetComponent<PlayerStats>();
            playerHp.Hp -= 1;
        }
    }
}
