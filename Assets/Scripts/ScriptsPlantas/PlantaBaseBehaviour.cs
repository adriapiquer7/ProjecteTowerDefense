using System;
using Unity.Mathematics;
using UnityEngine;

public class PlantaBaseBehaviour : MonoBehaviour
{
    [SerializeField]
    private string _nom;
    [SerializeField]
    private float _dany;
    [SerializeField]
    private float _velocitat;
    [SerializeField]
    private Sprite _sprite;
    [SerializeField]
    private float _forçaDispar;
    [SerializeField]
    private GameObject _prefabBala;

    private System.Collections.Generic.List<Transform> _zombies = new();
    
    private SpriteRenderer _spriteRenderer;
    private float _tempsTranscurrit;

    public static event Action<Vector3> OnDead;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Iniciar(Vector3 posicio, SOPlantaBase info)
    {
        transform.position=posicio;
        _nom=info.Nom;
        _dany=info.Dany;
        _velocitat=info.Velocitat;
        _sprite=info.Imatge;
        _spriteRenderer.sprite = _sprite;
        _forçaDispar=info.forçaDispar;
        _prefabBala=info.Bala;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        _zombies.Add(collision.transform);
    }

    /*void OnTriggerExit2D(Collider2D collision)
    {
        _zombies.Remove(collision.transform);
    }*/

    void Update()
    {
        _tempsTranscurrit+=Time.deltaTime;
        if (_tempsTranscurrit >= _velocitat && _zombies.Count > 0)
        {
            _tempsTranscurrit=0;
            GameObject balaInstanciada = Instantiate(_prefabBala, transform.position, quaternion.identity);
            balaInstanciada.GetComponent<Rigidbody2D>().linearVelocityX=_forçaDispar;
        }
    }

}
