using UnityEngine;
using Zenject;

public class SimpleEnemy: MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _enemySprite;
    
    private GameObject _player;
        
    [Inject] public void Inject(GameObject player)
    {
        _player = player;
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

        if (transform.position.x > _player.transform.position.x)
        {
            _enemySprite.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (transform.position.x < _player.transform.position.x)
        {
            _enemySprite.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
