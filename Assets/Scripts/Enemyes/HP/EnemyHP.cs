using UnityEngine;
using Zenject;

public class EnemyHP : MonoBehaviour, IDamageble
{
    [SerializeField] private int _takeDamage;
    
    public int _hp = 100;

    private HealthBar _healthBar;
    private GameObject _player;

    [Inject] private void GetHealthBar(HealthBar healthBar)
    {
        _healthBar = healthBar;
    }
    
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
        
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("saasf");
            GetDamage(_takeDamage);
        }
    }

    public void TakeDamage(int _damage)
    {
        _hp -= _damage;
    }

    public void GetDamage(int _getDamage)
    {
        _healthBar._hp--;
    }
}
