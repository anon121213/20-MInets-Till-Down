using System.Collections;
using UnityEngine;
using Zenject;

public class TakeXpMagnet: MonoBehaviour
{
    [SerializeField] private float _smoothness;

    private GameObject _player;
    private float _speed;

    [Inject]
    private void Inject(GameObject player)
    {
        _player = player;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<Xp>(out Xp _xp))
        {
            StartCoroutine(Magnet(collider.gameObject));
        }
    }

    public IEnumerator Magnet(GameObject _xp)
    {
        while (_xp.transform.position != _player.transform.position + new Vector3(1f, 1f, 1f))
        {
            if (_xp)
            {
                _xp.transform.position = Vector2.Lerp(_xp.transform.position, _player.transform.position, _smoothness * Time.deltaTime);
                yield return null;
            }
        }
    }
}
