using UnityEngine;
namespace SOEvent
{

    // La creamos por si acaso por si necesitamos usar eventos comn valores float

[CreateAssetMenu(fileName = "SOFloat", menuName = "Scriptable Objects/SOFloat")]
    public class SOFloat : ScriptableObject
        {
            [SerializeField]
            private float _value;

            public event System.Action<float> OnValueChanged;

            public float Value
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