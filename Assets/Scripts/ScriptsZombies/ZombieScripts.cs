using System;
using UnityEngine;

public class ZombieScripts : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;

    private string _nom;

    public float _vida;

    [SerializeField]
    private float _velocitat;

    private float _dany;

    private Sprite _sprite;

    private Animator _animator;

    private SpriteRenderer _spriteRenderer; 

    public void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Iniciar(Vector3 posicio, SOZombiesItems info)
    {
        transform.position=posicio;
        _nom=info.Nom;
        _vida=info.Vida;
        _dany=info.Dany;
        _velocitat=info.Velocitat;
        _sprite=info.Imatge;
        _animator=info.Animacio;
        //_spriteRenderer.sprite = _sprite;
        _rigidbody2D.linearVelocityX = -_velocitat;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pajaros"))
        {
            Console.WriteLine("Es un pajaro");
            _rigidbody2D.linearVelocityX = -_velocitat;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pajaros"))
        {
            Console.WriteLine("Ya no es un pajaro");
            _rigidbody2D.linearVelocityX = -_velocitat;   
        }
    }


    public event System.Action OnZombieHaMort;

    public void HacerDano(int dany)
    {
        
        _vida -= dany;

        if(_vida <= 0)
        {
            
            OnZombieHaMort?.Invoke();
            Destroy(gameObject);
        }

    }



}
