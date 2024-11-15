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
        if (other.TryGetComponent<InventoryMono>(out InventoryMono inventory) && !inventory.Inventory.IsFull())
        {
            inventory.Inventory.AddItem(_item, out int index);
            inventory.InvUI.AddItem(_sprite, index);
            Destroy(gameObject);
        }
    }
}
