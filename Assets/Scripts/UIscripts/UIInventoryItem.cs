using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private Image _sprite;

        [SerializeField]
        private TextMeshProUGUI _text;

        public void Init(SOPlantaBase item, Action<SOPlantaBase> interactFunc)
        {
            _sprite.sprite = item.Imatge;
            _text.text = item.Nom;

            //vincular el click del botó via codi
            //enviant el nostre propi esdeveniment
            _button.onClick.AddListener(() => interactFunc.Invoke(item));
        }
    }
