using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float _speed; 
    
    private Rigidbody2D _rb;
    private IInput _IInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _IInput = GetComponent<IInput>();
        QualitySettings.vSyncCount = 0;
    }
    
    private void Move(Vector2 direction)
    {
        _rb.velocity = direction * _speed;
    }
    
    private void OnEnable()
    {
        _IInput.Move += Move;
    }
    
    private void OnDisable()
    {
        _IInput.Move -= Move;
    }
}
