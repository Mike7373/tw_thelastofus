using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Image> _slotList = new();
    public List<Image> SlotList
    {
        get { return _slotList; }
    }

    private void Start()
    {
        InventoryMono.Instance.InvUI = this;
    }

    public void AddItem(Sprite sprite, int index)
    {
        _slotList[index].sprite = sprite;
    }

    public void RemoveItem(int index)
    {
        _slotList[index].sprite = null;
    }
}
