using System;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;

    private int _hp = 10;

    private float _time;

    [SerializeField]
    private float _speed = -0.8f;

    public void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.linearVelocityX = _speed;


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        _speed = 0;        
        _rigidbody2D.linearVelocityX = _speed;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        _speed = -0.8f;        
        _rigidbody2D.linearVelocityX = _speed;
    }

    public void hit(int _hpRebut) {

        

    }
}
