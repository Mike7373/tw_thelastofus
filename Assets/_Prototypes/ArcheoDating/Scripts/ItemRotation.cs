using UnityEngine;

namespace ArcheoDating
{
    [RequireComponent(typeof(ItemDragDrop))]
    public class ItemRotation : MonoBehaviour
    {
        [SerializeField] private int _rotationSpeed = 5;
        private ItemDragDrop _dragDrop;

        private void Awake()
        {
            _dragDrop = GetComponent<ItemDragDrop>();
        }

        private void Update()
        {
            if (_dragDrop.isDragging)
            {
                Rotate();
            }
        }

        private void Rotate()
        {
            //Asse x
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.right, _rotationSpeed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.left, _rotationSpeed);
            }

            //Asse y
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(Vector3.up, _rotationSpeed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(Vector3.down, _rotationSpeed);
            }

            //Asse z
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.forward, _rotationSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.back, _rotationSpeed);
            }
        }
    }
}