using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPBar: MonoBehaviour
{
    [SerializeField] private Image _helthBar;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private TextMeshProUGUI _xpCount;
    [SerializeField] private UpgradePanel _upgradePanel;

    private void Update()
    {
        HealthBarCalculate();
    }

    private void HealthBarCalculate()
    {
        if (_playerStats.Xp >= _playerStats.XpForNewLvl)
        {
            _playerStats.Xp = 0;
            _playerStats.XpForNewLvl += 20;
            _playerStats.Lvl += 1;
            _upgradePanel.OpenPanel();
        }

        _xpCount.text = $"LEVEL {_playerStats.Lvl}";
        _helthBar.fillAmount = (float)_playerStats.Xp / _playerStats.XpForNewLvl;
    }
}
