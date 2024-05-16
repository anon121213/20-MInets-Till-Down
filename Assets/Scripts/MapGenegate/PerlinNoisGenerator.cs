using UnityEngine;
using Zenject;

public class TreeGenegator : MonoBehaviour
{
    [Tooltip("Минимальное расстояние между деревьями (сид)"), SerializeField] private float _minScale = 300f;
    [Tooltip("Максимальное расстояние между деревьями (сид)"), SerializeField] private float _maxScale = 600f;
    [Tooltip("Плотность деревьев, чеб больше тем меньше"), Range(0f, 1f), SerializeField] private float _density;
    [SerializeField] private float _treeCheckSphereRadius;
    
    [Space]
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private GameObject _treeEmptyGO;

    [Inject] private DiContainer _diContainer;
    
    private Vector2 _mapScale;
    private float _seed;

    private void Start()
    {
        _seed = Random.Range(_minScale, _maxScale);
        _mapScale = CalculateMapScale(_firstPoint, _secondPoint);
        float[,] noiseMap = GenerateNoiseMap();
        PlaceObjectsOnMap(noiseMap);
    }

    private Vector2 CalculateMapScale(Transform firstPoint, Transform secondPoint)
    {
        return new Vector2(secondPoint.position.x - firstPoint.position.x, secondPoint.position.y - firstPoint.position.y);
    }
    
    private float[,] GenerateNoiseMap()
    {
        float[,] noiseMap = new float[Mathf.RoundToInt(_mapScale.x), Mathf.RoundToInt(_mapScale.y)];

        for (int x = 0; x < noiseMap.GetLength(0); x++)
        {
            for (int y = 0; y < noiseMap.GetLength(1); y++)
            {
                float xCoord = (float)x / _mapScale.x * _seed;
                float yCoord = (float)y / _mapScale.y  * _seed;

                noiseMap[x, y] = Mathf.PerlinNoise(xCoord, yCoord);
            }
        }

        return noiseMap;
    }
    
    private void PlaceObjectsOnMap(float[,] noiseMap)
    {
        for (int x = 0; x < noiseMap.GetLength(0); x++)
        {
            for (int y = 0; y < noiseMap.GetLength(1); y++)
            {
                if (noiseMap[x, y] > _density)
                {
                    Vector3 position = new Vector3(x - (_mapScale.x / 2) - 50, y - (_mapScale.y / 2) - 25, 0);
                    var hit = Physics2D.OverlapCircle(position, _treeCheckSphereRadius);

                    if (!hit)
                    {
                        _diContainer.InstantiatePrefab(_treePrefab, position, Quaternion.identity, _treeEmptyGO.transform);
                    }
                }
            }
        }
    }
}
