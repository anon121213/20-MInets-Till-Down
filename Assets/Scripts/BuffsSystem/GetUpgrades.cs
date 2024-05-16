using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GetUpgrades : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private UpgradePanel _upgradePanel;
    [SerializeField] private Button _upgradeButton;
    
    private GameObject _player;
    private PlayerStats _playerStats;
    private Character _character;
    private Gun _gun;
    private Bullets _bullet;
    
    public UpgradesType _targetUpgrade = UpgradesType.empty;
    
    [Inject] private void Inject (GameObject player)
    {
        _player = player;
    }

    private void Start()
    {
        _playerStats = _player.GetComponent<PlayerStats>();
        _gun = _player.GetComponentInChildren<Gun>();
        _bullet = _bulletPrefab.GetComponent<Bullets>();
        _character = _player.GetComponent<Character>();
        _upgradeButton.onClick.AddListener(Upgrade);
    }

    private void Upgrade()
    {
        Upgrades();
    }

    private void Upgrades()
    {
        switch (_targetUpgrade)
        {
            case UpgradesType.shootSpeed:
                _gun.ShootSpeed -= 0.05f;
                _upgradePanel.ClousePanel();
                break;
            
            case UpgradesType.damage:
                _bullet.Damage += 20;
                _upgradePanel.ClousePanel();
                break;
            
            case UpgradesType.speed:
                _character.Speed += 3f;
                _upgradePanel.ClousePanel();
                break;
            
            case UpgradesType.hp:
                _playerStats.Hp += 1;
                _upgradePanel.ClousePanel();
                break;
            
            case UpgradesType.reloadDelay:
                _gun.ReloadDelay -= 0.2f;
                _upgradePanel.ClousePanel();
                break;
            case UpgradesType.bulletSpeed:
                _bullet.Damage += 3;
                _upgradePanel.ClousePanel();
                break;
        }
    }
}
