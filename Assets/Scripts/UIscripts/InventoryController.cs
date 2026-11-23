using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private SOInt _money;
        public event Action<int> OnDisplayMoney;

        [SerializeField]
        private List<SOItem> _items;
        public event Action<SOItem[]> OnDisplayItems;

        [SerializeField]
        private InventoryController _purchaserController;

        private void Start()
        {
            _money.OnValueChanged += OnDisplayMoney;

            OnDisplayMoney.Invoke(_money.Value);
            OnDisplayItems?.Invoke(_items.ToArray());
        }

        private void OnDestroy()
        {
            _money.OnValueChanged -= OnDisplayMoney;
        }


        public bool TryPurchase(SOItem item)
        {
            if (item.Price <= _money.Value)
            {
                _money.Value -= item.Price;
                _items.Add(item);
                OnDisplayItems?.Invoke(_items.ToArray());
                return true;
            }

            return false;
        }

        public bool TrySell(SOItem item)
        {
            Debug.Assert(_items.Contains(item), $"{this.name}: L'objecte {item.Name} no és a l'inventari");

            if (_purchaserController.TryPurchase(item))
            {
                _money.Value += item.Price;
                _items.Remove(item);
                OnDisplayItems?.Invoke(_items.ToArray());
                return true;
            }
            return false;
        }
    }