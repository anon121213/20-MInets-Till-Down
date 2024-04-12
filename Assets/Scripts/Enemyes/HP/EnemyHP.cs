using UnityEngine;

public class EnemyHP : MonoBehaviour, IDamageble
{
    public int _hp = 100;

    private void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetDamage(int _damage)
    {
        _hp -= _damage;
    }
}
