using UnityEngine;

[CreateAssetMenu(fileName = "SOZombiesItems", menuName = "Scriptable Objects/SOZombiesItems")]
public class SOZombiesItems : ScriptableObject
{

    [SerializeField]
    private string _nom;
    public string Nom => _nom;
    [SerializeField]
    private float _vida;
    public float Vida =>_vida;
    [SerializeField] 
    private float _velocitat;
    public float Velocitat => _velocitat;
    [SerializeField] 
    private float _dany;
    public float Dany => _dany;
    [SerializeField]
    private Sprite _sprite;
    public Sprite Imatge =>_sprite;
    [SerializeField]
    private Animator _animator;
    public Animator Animacio=>_animator;
    
}
