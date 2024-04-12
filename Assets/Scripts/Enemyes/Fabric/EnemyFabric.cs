using System.Collections;
using UnityEngine;
using Zenject;

public class EnemyFabric : MonoBehaviour
{
    [SerializeField] private GameObject _sympleEnemyPrefab;
    [SerializeField] private float spawnInterval = 2.0f;
    
    [Inject] private GameObject _player;
    
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
            yield return new WaitForSeconds(spawnInterval);

            // Выберите случайную сторону (0 = верх, 1 = право, 2 = низ, 3 = лево)
            int side = Random.Range(0, 4);

            Vector2 spawnPosition = Vector2.zero;

            switch (side)
            {
                case 0: // Верх
                    spawnPosition =
                        new Vector2(
                            Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x,
                                mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x),
                            mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y);
                    break;
                case 1: // Право
                    spawnPosition = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x,
                        Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y,
                            mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y));
                    break;
                case 2: // Низ
                    spawnPosition =
                        new Vector2(
                            Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x,
                                mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x),
                            mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y);
                    break;
                case 3: // Лево
                    spawnPosition = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x,
                        Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y,
                            mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y));
                    break;
            }

            var go = Instantiate(_sympleEnemyPrefab, spawnPosition, Quaternion.identity);
            var enemy = go.GetComponent<SimpleEnemy>();
            enemy.GetPlayer(_player);
        }
    }
}

