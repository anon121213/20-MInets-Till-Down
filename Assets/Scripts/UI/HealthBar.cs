using UnityEngine;
using Zenject;

public class HealthBar: MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _heartSprites = {};
    
    private SimpleEnemy _simpleEnemy;
    private GameObject _player;
    private int _hp;
        
    [Inject] public void GetPlayer(GameObject player)
    {
        _player = player;
    }
    
    private void Update()
    {
        _hp = _player.GetComponent<PlayerStats>().Hp;
        ShowHp();
    }

    private void ShowHp()
    {
        foreach (var element in _heartSprites)
        {
            element.gameObject.SetActive(false);
        }
        
        _heartSprites[_hp].gameObject.SetActive(true);
    }
}