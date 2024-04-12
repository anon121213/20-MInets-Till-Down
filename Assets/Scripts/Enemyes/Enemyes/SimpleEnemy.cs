using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class SimpleEnemy: MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private GameObject _player;
    private NavMeshAgent _nav;
        
    [Inject] public void GetPlayer(GameObject player)
    {
        _player = player;
    }

    private void Awake()
    {
        _nav = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        _nav.SetDestination(_player.transform.position);
    }
}
