using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _hp = 4;
    [SerializeField] private int _maxHp = 4;
    [SerializeField] private int _xp = 0;
    [SerializeField] private int _xpForNewLvl = 100;
    [SerializeField] private int _lvl = 1;
    [SerializeField] private int _specialLvlPoint = 0;

    public int MaxHp
    {
        get => _maxHp;
        set => _maxHp = Mathf.Clamp(value, 0, 8);
    } 
    
    public int Hp
    {
        get => _hp;
        set => _hp = Mathf.Clamp(value, 0, int.MaxValue);
    }

    public int Xp
    {
        get => _xp;
        set => _xp = Mathf.Clamp(value, 0, int.MaxValue);
    }
    
    public int XpForNewLvl
    {
        get => _xpForNewLvl;
        set => _xpForNewLvl = Mathf.Clamp(value + value, 0, int.MaxValue);
    }
    
    public int Lvl
    {
        get => _lvl;
        set => _lvl = Mathf.Clamp(value, 0, int.MaxValue);
    }
    
    public int SpecialLvlPoint
    {
        get => _specialLvlPoint;
        set => _specialLvlPoint = Mathf.Clamp(value, 0, int.MaxValue);
    }
}
