using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class NewScriptableObjectScript : ScriptableObject
{
    [SerializeField]
    private float _hp = 10;

    [SerializeField]
    private float _atk = 2;

    [SerializeField]
    private int _speed = 1;

    
}
