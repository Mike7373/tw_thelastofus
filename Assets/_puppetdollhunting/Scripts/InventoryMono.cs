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

    public Inventory GetInventory => _inventory;

    public InventoryUI InvUI
    {
        get => _invUI;
        set{}
    }

    #endregion
    

    private void Awake()
    {
        if (Instance == null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Start()
    {
        _inventory = new Inventory(_invUI.SlotList.Count);
    }
}
