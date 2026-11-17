using UnityEngine;
namespace SOEvent
{

[CreateAssetMenu(fileName = "SOInt", menuName = "Scriptable Objects/SOInt")]
    public class SOInt : ScriptableObject
        {
            [SerializeField]
            private int _value;

            public event System.Action<int> OnValueChanged;

            public int Value
            {
                get => _value;
                set
                {
                    _value = value;
                    OnValueChanged?.Invoke(_value);
                }
            }
    }

}