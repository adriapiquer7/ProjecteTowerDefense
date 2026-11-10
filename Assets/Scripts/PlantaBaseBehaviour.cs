using UnityEngine;

public class PlantaBaseBehaviour : MonoBehaviour
{
    private string _nom;
    private float _dany;
    private float _velocitat;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Iniciar(Vector3 posicio, SOPlantaBase info)
    {
        transform.position=posicio;
        _nom=info.Nom;
        _dany=info.Dany;
        _velocitat=info.Velocitat;
        _spriteRenderer=info.Sprite;
    }
}
