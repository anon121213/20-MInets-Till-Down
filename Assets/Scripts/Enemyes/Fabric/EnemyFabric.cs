using UnityEngine;
using Zenject;

public class EnemyFabric : MonoBehaviour
{
    [Inject] private GameObject _player;
    [SerializeField] private GameObject _sympleEnemyPrefab;
    
    public void SpawnSimpleEnemy()
    {
        var go = Instantiate(_sympleEnemyPrefab);
        var enemy = go.GetComponent<SimpleEnemy>();
        enemy.GetPlayer(_player);
    }

    private void Start()
    {
        SpawnSimpleEnemy();
    }
}

