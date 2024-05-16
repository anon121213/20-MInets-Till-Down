using System.Collections;
using UnityEngine;
using Zenject;

public class EnemyFabric : MonoBehaviour
{
    [SerializeField] private GameObject _sympleEnemyPrefab;
    [SerializeField] private float spawnInterval = 2.0f;
    [SerializeField] private GameObject _enemys;
    [SerializeField] private Transform _emptyXP;
    
    [Inject] private GameObject _player;
    [Inject] private DiContainer _diContainer;
    
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnSimpleEnemy());
    }
    
    IEnumerator SpawnSimpleEnemy()
    {
        while (true)
        {
            var wait = new WaitForSeconds(spawnInterval);
            yield return wait;

            int side = Random.Range(0, 4);

            var spawnPosition = Vector2.zero;

            switch (side)
            {
                case 0: // Верх
                    spawnPosition =
                        new Vector3(
                            Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x,
                                mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x),
                            mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y, 1.5f);
                    break;
                case 1: // Право
                    spawnPosition = new Vector3(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x,
                        Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y,
                            mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y), 1.5f);
                    break;
                case 2: // Низ
                    spawnPosition =
                        new Vector3(
                            Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x,
                                mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x),
                            mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y);
                    break;
                case 3: // Лево
                    spawnPosition = new Vector3(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x,
                        Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y,
                            mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y), 1.5f);
                    break;
            }

            var difspawn = new Vector3(spawnPosition.x, spawnPosition.y, 1.5f);
            var go = _diContainer.InstantiatePrefab(_sympleEnemyPrefab, difspawn, Quaternion.identity, _enemys.transform);
            
            var enemy = go.GetComponent<SimpleEnemy>();
            var enemyDamage = go.GetComponent<EnemyDamage>();
            
            enemyDamage._emptyXp = _emptyXP;
            enemy.GetPlayer(_player);
        }
    }
}

