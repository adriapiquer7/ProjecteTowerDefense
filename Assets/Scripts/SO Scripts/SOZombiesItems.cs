using UnityEngine;

[CreateAssetMenu(fileName = "SOZombiesItems", menuName = "Scriptable Objects/SOZombiesItems")]
public class SOZombiesItems : ScriptableObject
{

    [SerializeField]
    private string _nom = "Zomnie Base";
    public string Nom => _nom;
    public void SetNom(string Nom)
    {
        this._nom = Nom;
    }

    [SerializeField]
    private Sprite _sprite;

    [SerializeField]
    private int _hp;

    [SerializeField]
    private int _atk;

    [SerializeField]
    private int _speed;
    
}
