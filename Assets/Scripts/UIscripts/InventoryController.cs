using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private SOInt _money;
        public event Action<int> OnDisplayMoney;

        [SerializeField]
        private List<SOPlantaBase> _items;
        public event Action<SOPlantaBase[]> OnDisplayItems;

        [SerializeField]
        private InventoryController _purchaserController;

        private void Start()
        {
            _money.OnValueChanged += OnDisplayMoney;

            OnDisplayMoney.Invoke(_money.Value);
        }

        private void OnDestroy()
        {
            _money.OnValueChanged -= OnDisplayMoney;
        }


        public bool TryPurchase(SOPlantaBase item)
        {
            if (item.Cost <= _money.Value)
            {
                _money.Value -= item.Cost;
                return true;
            }

            return false;
        }
    }