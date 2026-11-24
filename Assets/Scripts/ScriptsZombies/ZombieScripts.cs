using System;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class ZombieScripts : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;

    private string _nom;

    private float _vida;

    private float _velocitat;

    private float _dany;

    private Sprite _sprite;

    private Animator _animator;

    private SpriteRenderer _spriteRenderer;    

    public void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    public void Iniciar(SOZombiesItems info)
    {
        _nom=info.Nom;
        _vida=info.Vida;
        _dany=info.Dany;
        _velocitat=info.Velocitat;
        _sprite=info.Imatge;
        _animator=info.Animacio;
        _spriteRenderer.sprite = _sprite;
        _rigidbody2D.linearVelocityX = _velocitat;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Console.WriteLine("Es algo");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pajaros"))
        {
            Console.WriteLine("Es un pajaro");
            //_zombie.Velocitat = 0.0f;        
            _rigidbody2D.linearVelocityX = _velocitat;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Console.WriteLine("Ya no es algo");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pajaros"))
        {
            Console.WriteLine("Ya no es un pajaro");
            //_soZombiesItems.Velocitat = -0.8f;        
            _rigidbody2D.linearVelocityX = _velocitat;   
        }
    }


}
