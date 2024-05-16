using UnityEngine;
using TMPro;

public class AmmoBar: MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private TextMeshProUGUI _tmp;

    private int _maxAmmo;
    
    private void Start()
    {
        _maxAmmo = _gun.Ammo;
    }

    private void Update()
    {
        _tmp.text = $"00{_gun.Ammo} / 00{_maxAmmo}";
    }
}
