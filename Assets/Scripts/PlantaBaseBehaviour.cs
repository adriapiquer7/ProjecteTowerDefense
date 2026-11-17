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
    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

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
        _animator=info.Animacio;
        _spriteRenderer.sprite = _sprite;
    }
    
}
