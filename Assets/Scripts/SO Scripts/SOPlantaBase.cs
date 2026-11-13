using UnityEngine;

[CreateAssetMenu(fileName = "PlantaBase", menuName = "Scriptable Objects/PlantaBase")]
public class SOPlantaBase : ScriptableObject
{
    [SerializeField] 
    private string _nom;
    public string Nom => _nom;
    [SerializeField] 
    private float _velocitat;
    public float Velocitat => _velocitat;
    [SerializeField] 
    private float _dany;
    public float Dany => _dany;
}
