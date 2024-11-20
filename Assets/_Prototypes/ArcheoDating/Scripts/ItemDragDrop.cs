using System;
using UnityEngine;

namespace ArcheoDating
{
    [RequireComponent(typeof(Rigidbody))]
    public class ItemDragDrop : MonoBehaviour
    {
        private Vector3 _mousePosition;
        private float _yPos;
        private Rigidbody _rb;
        public bool isDragging;

        private void Start()
        {
            _yPos = transform.position.y;
            _rb = GetComponent<Rigidbody>();
        }

        private Vector3 GetMousePosition()
        {
            return Camera.main.WorldToScreenPoint(transform.position);
        }

        private void OnMouseDown()
        {
            _mousePosition = Input.mousePosition - GetMousePosition();
            _rb.isKinematic = true;
            Cursor.visible = false;
            isDragging = true;
        }

        private void OnMouseDrag()
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
            transform.position = new Vector3(newPos.x, _yPos, newPos.z);
        }

        private void OnMouseUp()
        {
            _rb.isKinematic = false;
            Cursor.visible = true;
            isDragging = false;
        }
    }
}