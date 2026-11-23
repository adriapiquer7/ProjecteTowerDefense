using UnityEngine;

public class ZombieBaseBehavior : MonoBehaviour
{
    private string _nom;

    private float _vida;

    private float _velocitat;

    private float _dany;

    private Sprite _sprite;

    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

        private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
    }
}
