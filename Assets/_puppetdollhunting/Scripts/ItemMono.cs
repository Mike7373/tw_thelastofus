using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemMono : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    
    private Item _item;

    private void Start()
    {
        _item = new Item(_name, _sprite);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<InventoryMono>(out InventoryMono inventory) && !inventory.GetInventory.IsFull())
        {
            inventory.GetInventory.AddItem(_item, out int index);
            inventory.InvUI.AddItem(_sprite, index);
            Destroy(gameObject);
        }
    }
}
