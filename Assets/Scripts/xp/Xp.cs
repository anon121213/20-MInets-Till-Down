using UnityEngine;
using Zenject;

public class Xp: MonoBehaviour
{
    [SerializeField] private int _getXpCount;

    private WinSystem _winSystem;
    private TakeXpMagnet _takeXpMagnet;
    
    [Inject] private void Inject (WinSystem winSystem)
    {
        _winSystem = winSystem;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats _cherecterStats))
        {
            _cherecterStats.Xp += _getXpCount;
            _winSystem._xpCount += _getXpCount;
            print(_cherecterStats.Xp);
            print(_cherecterStats.Lvl);
            Destroy(gameObject);
        }
    }
}
