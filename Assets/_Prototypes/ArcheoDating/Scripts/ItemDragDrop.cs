using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ArcheoDating
{
    public class ItemDragDrop : MonoBehaviour
    {
        private Vector3 _mousePosition;
        private float _yPos;
        private Rigidbody _rb;
        public bool isDragging;
        private List<Collider> _triggerList = new();
        private Collider _collider;

        private void Start()
        {
            _yPos = transform.position.y;
            _rb = GetComponent<Rigidbody>();
            _triggerList = GetComponentsInChildren<Collider>().ToList();
            _collider = GetComponent<Collider>();
            
            foreach (Collider collider in _triggerList)
            {
                if (!collider.isTrigger)
                {
                    _triggerList.Remove(collider);
                    break;
                }
            }
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
            
            ToggleTriggers(false);
        }

        private void OnMouseDrag()
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
            transform.position = new Vector3(newPos.x, _yPos, newPos.z);
        }

        private void OnMouseUp()
        {
            Cursor.visible = true;
            isDragging = false;
            if (Stickable.currentTargets.Count > 0)
            {
                Destroy(_rb);
                transform.parent = Stickable.currentTargets[^1].transform;
                Stickable.currentTargets.Remove(Stickable.currentTargets[^1]);
                transform.localPosition = Vector3.zero;
                _rb.isKinematic = false;
                _collider.enabled = false;
                enabled = false;
                return;
            }
            ToggleTriggers(true);
        }

        private void ToggleTriggers(bool toggle)
        {
            foreach (Collider collider in _triggerList)
            {
                collider.enabled = toggle;
            }
        }
    }
}