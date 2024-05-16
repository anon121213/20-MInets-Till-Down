using UnityEngine;
using TMPro;
using System.Collections.Generic;

public enum UpgradesType
{
    shootSpeed,
    damage,
    speed,
    hp,
    reloadDelay,
    bulletSpeed,
    empty
}

public class Upgrades: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buffDescription;
    [SerializeField] private GetUpgrades _getUpgrades;
    [SerializeField] private UpgradesType _upgradesTypes;
    
    private UpgradesType _selectedUpgradeType = UpgradesType.empty;
    private UpgradesType _upgradesType = UpgradesType.empty;
    
    private Dictionary<UpgradesType, string> _buffDescriptions = new Dictionary<UpgradesType, string>
    {
        { UpgradesType.shootSpeed, "Увеличение скорости стрельбы на 15%" },
        { UpgradesType.damage, "Увеличение урона на 20%" },
        { UpgradesType.speed, "Увеличение скорости персонажа на 10%" },
        { UpgradesType.hp, "Увеличение количества здоровья на 1 еденицу" },
        { UpgradesType.reloadDelay, "Увеличение скорости перезарядки на 15%" },
        { UpgradesType.bulletSpeed, "Увеличение скорости пули на 10%" }
    };
    
    public void SelectUpgrade()
    {
        _selectedUpgradeType = _upgradesTypes;
        _buffDescription.text = _buffDescriptions[_selectedUpgradeType];
        
        Upgrade();
    }
    
    private void Upgrade()
    {
        if (_selectedUpgradeType != UpgradesType.empty)
        {
            _upgradesType = _selectedUpgradeType;
            _getUpgrades._targetUpgrade = _upgradesType;
        }
    }
}