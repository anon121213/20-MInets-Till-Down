using UnityEngine;

public class GunRotate : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    
    private IInput _IInput;
    
    private void Awake()
    {
        _IInput = _player.GetComponent<IInput>();
    }

    private void Rotate()
    {
        if (DeviceCheck.DeviseChecker())
        {
            _IInput.ShootingJoy += GunRotaiterMobile;
        }
        else
        {
            GunRotaiterPC();
        }
    }

    private void GunRotaiterPC()
    {
        var _mousePos = Input.mousePosition;
        var _objectPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        
        var _angle = Mathf.Atan2(_mousePos.x - _objectPos.x, _mousePos.y - _objectPos.y) * Mathf.Rad2Deg;

        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -_angle));

        if (gameObject.transform.eulerAngles.z >= 0 && gameObject.transform.eulerAngles.z < 180)
        {
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    
    private void GunRotaiterMobile(Vector2 _RotateDirection)
    {
        var _angle = Mathf.Atan2(_RotateDirection.y, _RotateDirection.x) * Mathf.Rad2Deg - 90f;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -_angle));
    
        if (gameObject.transform.eulerAngles.z >= 0 && gameObject.transform.eulerAngles.z < 180)
        {
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    
    
    private void Update()
    {
        Rotate();
    }
}
