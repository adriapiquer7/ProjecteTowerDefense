using UnityEngine;

[CreateAssetMenu(fileName = "SOitem", menuName = "Scriptable Objects/SOitem")]
public class SOItem : ScriptableObject
{
    [SerializeField]
        private Sprite _sprite;
        public Sprite Sprite => _sprite;

        [SerializeField]
        private string _name;
        public string Name => _name;

        [SerializeField]
        private int _price;
        public int Price => _price;
}
