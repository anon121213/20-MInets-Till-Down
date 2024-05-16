using UnityEngine;
using Zenject;

public class SimpleEnemy: MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private GameObject _player;
        
    [Inject] public void GetPlayer(GameObject player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.fixedDeltaTime);

        if (transform.position.x > _player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (transform.position.x < _player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
