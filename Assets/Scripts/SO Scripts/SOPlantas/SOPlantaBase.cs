using UnityEngine;

[CreateAssetMenu(fileName = "PlantaBase", menuName = "Scriptable Objects/PlantaBase")]
public class SOPlantaBase : ScriptableObject
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
    private float _forçaDispar;
    public float forçaDispar=>_forçaDispar;
    [SerializeField]
    private GameObject _proyectil;
    public GameObject Bala => _proyectil;
}
