using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tile[] _tile;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    private Vector3Int _firstPointInt;
    private Vector3Int _secondPointInt;
    private int _totalTile;
    private float _progress;

    public float Progress { get { return _progress; } }

    private void Awake()
    {
        _firstPointInt = _tilemap.WorldToCell(_firstPoint.position);
        _secondPointInt = _tilemap.WorldToCell(_secondPoint.position);
        
        StartCoroutine(PlaceTile(_firstPointInt, _secondPointInt));
    }

    private IEnumerator PlaceTile(Vector3Int firstPoint, Vector3Int secondPoint)
    {
        Time.timeScale = 0f;

        _totalTile = Mathf.Abs(_secondPointInt.x - _firstPointInt.x) * Mathf.Abs(_secondPointInt.y - _firstPointInt.y);
        var tilesPlaced = 0;
        
        for (int x = firstPoint.x; x <= secondPoint.x; x++)
        {
            for (int y = firstPoint.y; y <= secondPoint.y; y++)
            {
                var position = new Vector3Int(x, y, 0);
                _tilemap.SetTile(position, _tile[Random.Range(0, _tile.Length)]);
                
                tilesPlaced++;
                _progress = (float)tilesPlaced / _totalTile;
                print(_progress);
                
                if (tilesPlaced % 100 == 0)
                {
                    yield return null;
                }
            }
        }
    }
}