using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody))]

public class Bullets : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void FlyBullet()
    {
        _rb.velocity = transform.up * _speed * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        FlyBullet();
    }
}
