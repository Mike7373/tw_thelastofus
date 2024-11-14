using UnityEngine;

public class Inventory
{
    private Item[] _itemList;

    public Inventory(int invSize)
    {
        _itemList = new Item[invSize];
    }

    public void ToString()
    {
        string result = "";
        for (int i = 0; i < _itemList.Length; i++)
        {
            if (_itemList[i] == null)
            {
                return;
            }
            result += $"{_itemList[i].ItemName}\n";
        }

        if (result != "")
        {
            Debug.Log("[Inventory] Inventory Items:\n" + result);
        }
        else
        {
            Debug.Log("[Inventory] The inventory is empty");
        }
    }

    public bool IsEmpty()
    {
        for (int i = 0; i < _itemList.Length; i++)
        {
            if (_itemList[i] != null)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsFull()
    {
        for (int i = 0; i < _itemList.Length; i++)
        {
            if (_itemList[i] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void AddItem(Item item, out int index)
    {
        for (int i = 0; i < _itemList.Length; i++)
        {
            if (_itemList[i] == null)
            {
                _itemList[i] = item;
                index = i;
                return;
            }
        }
        index = -1;
        Debug.LogError("You tried to add an item but the list is full!");
    }

    public void UseItem(int index)
    {
        
    }
}