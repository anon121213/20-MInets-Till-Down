using UnityEngine;
using Zenject;

public class EnemyHP : MonoBehaviour, IDamageble
{
    [SerializeField] private int _takeDamage;
    [SerializeField] private float _pushForce;

    public int _hp = 100;
    
    private GameObject _player;
        
    [Inject] public void GetPlayer(GameObject player)
    {
        _player = player;
    }
    
    private void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.GetComponent<CharacterMove>())
        {
            GetDamage(_takeDamage);
        }
    }

    public void TakeDamage(int _damage)
    {
        _hp -= _damage;
    }

    public void GetDamage(int _getDamage)
    {
        var _playerHp = _player.gameObject.GetComponent<CaharacterStats>()._hp;

        if (_playerHp > 0)
        {
            var pushDirection = -(transform.position - _player.transform.position).normalized;
            var _playerRb = _player.gameObject.GetComponent<Rigidbody2D>();
            
            _playerRb.AddForce(pushDirection * _pushForce * 1000);
            
            _player.gameObject.GetComponent<CaharacterStats>()._hp--;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
