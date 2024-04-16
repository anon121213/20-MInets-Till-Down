using System;
using UnityEngine;
using Zenject;

public class HealthBar: MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _heartSprites = {};

    public int _hp = 4;

    private SimpleEnemy _simpleEnemy;
    private GameObject _player;
        
    [Inject] public void GetPlayer(GameObject player)
    {
        _player = player;
    }

    private void Start()
    {
        Debug.Log($"AfafaSF player: {_player}");
    }

    private void Update()
    {
        Debug.Log(_hp);
    }
}
