using UnityEngine;

[CreateAssetMenu(fileName = "Ronda", menuName = "Scriptable Objects/Ronda")]
public class Ronda : ScriptableObject
{
    
    [SerializeField]
    private int _rondaId;

    [SerializeField]
    private int _totalZombie;

    [SerializeField]
    private int _maxZombie;

    [SerializeField]
    private float _tempsEntreZombies;

}
