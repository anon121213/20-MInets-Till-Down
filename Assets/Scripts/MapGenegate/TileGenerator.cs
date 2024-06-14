using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class TilePlacer : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tile[] _tile;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    private Vector3Int _firstPointInt;
    private Vector3Int _secondPointInt;
    
    private void Awake()
    {
        _firstPointInt = _tilemap.WorldToCell(_firstPoint.position);
        _secondPointInt = _tilemap.WorldToCell(_secondPoint.position);
        
        PlaceTile(_firstPointInt, _secondPointInt);
    }

    private void PlaceTile(Vector3Int firstPoint, Vector3Int secondPoint)
    {
        print("a");
        for (int x = firstPoint.x; x <= secondPoint.x; x++)
        {
            print("b");
            for (int y = firstPoint.y; y <= secondPoint.y; y++)
            {
                print("c");
                var position = new Vector3Int(x, y, 0);
                print(position);
                _tilemap.SetTile(position, _tile[Random.Range(0, _tile.Length)]);
            }
        }
    }
}