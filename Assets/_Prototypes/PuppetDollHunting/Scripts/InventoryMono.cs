using System;
using UnityEngine;

public class InventoryMono : MonoBehaviour
{
    #region FIELDS

    private Inventory _inventory;
    private InventoryUI _invUI;
    public static InventoryMono Instance;

    #endregion
    
    #region PROPERTIES

    public Inventory Inventory
    {
        get => _inventory;
        set => _inventory = value;
    }

    public InventoryUI InvUI
    {
        get => _invUI;
        set => _invUI = value;
    }

    #endregion
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            _inventory.UseItem(0);
            _invUI.RemoveItem(0);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            _inventory.UseItem(1);
            _invUI.RemoveItem(1);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            _inventory.UseItem(2);
            _invUI.RemoveItem(2);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            _inventory.UseItem(3);
            _invUI.RemoveItem(3);
        }
    }
}
