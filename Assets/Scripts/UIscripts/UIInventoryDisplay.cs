using System;
using TMPro;
using UnityEngine;

public class UIInventoryDisplay : MonoBehaviour
    {
        [SerializeField]
        private SpawnPlantaBase _inventoryController;

        [SerializeField]
        private GameObject _UIDisplayItemPrefab;

        [SerializeField]
        private Transform _itemDisplayContainer;

        [SerializeField]
        private TextMeshProUGUI _moneyText;

        private void Awake()
        {
            _inventoryController.OnDisplayPlantas += DisplayTurrets;
        }

        private void OnDestroy()
        {
            _inventoryController.OnDisplayPlantas -= DisplayTurrets;
        }

        private void DisplayTurrets(SOPlantaBase[] plantas)
        {
            foreach (SOPlantaBase planta in plantas)
            {
                GameObject goDisplayItem = Instantiate(_UIDisplayItemPrefab, _itemDisplayContainer);
                UIInventoryItem uiDisplayItem = goDisplayItem.GetComponent<UIInventoryItem>();
                uiDisplayItem.Init(planta, _inventoryController.OnBuild);
            }
        }

        private void DisplayMoney(int money)
        {
            _moneyText.text = money.ToString();
        }
    }
