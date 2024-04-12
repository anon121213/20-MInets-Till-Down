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
    }
}
