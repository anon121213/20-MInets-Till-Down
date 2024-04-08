using UnityEngine;

public class GunRotatePc : MonoBehaviour
{
    [SerializeField] Transform _centralObject;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void GunRotaiter()
    {
        var _mousePos = Input.mousePosition;
        var _objectPos = Camera.main.WorldToScreenPoint(_centralObject.position);
        
        var angle = Mathf.Atan2(_mousePos.x - _objectPos.x, _mousePos.y - _objectPos.y) * Mathf.Rad2Deg;

        _centralObject.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));

        if (angle >= 0)
        {
            _spriteRenderer.flipY = false;
        }else
        {
            _spriteRenderer.flipY = true;
        }
    }
    
    private void Update()
    {
        GunRotaiter();
    }

}
