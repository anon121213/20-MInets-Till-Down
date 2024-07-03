using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image[] _heartSlots = {};
    [SerializeField] private Sprite _activeHeart;
    [SerializeField] private Sprite _nonActiveHeart;

    private Character _character;
    private PlayerStats _playerStats;
    private int _hp;
    private int _maxHp;

    [Inject]
    public void GetPlayer(GameObject player)
    {
        _character = player.GetComponent<Character>();
        _playerStats = player.GetComponent<PlayerStats>();
        _maxHp = _playerStats.MaxHp;
        _hp = _playerStats.Hp;
    }

    private void Start()
    {
        UpdateHearts();
    }

    private void ChangeHp(int damage)
    {
        _hp -= damage;
        _maxHp = _playerStats.MaxHp;
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < _heartSlots.Length; i++)
        {
            _heartSlots[i].sprite = (i < _hp) ? _activeHeart : _nonActiveHeart;
            
            _heartSlots[i].gameObject.SetActive(i < _maxHp);
        }
    }

    private void OnEnable()
    {
        _character.DamageTaken += ChangeHp;
    }

    private void OnDisable()
    {
        _character.DamageTaken -= ChangeHp;
    }
}