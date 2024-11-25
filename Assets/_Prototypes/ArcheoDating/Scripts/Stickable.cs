using System;
using System.Collections.Generic;
using ArcheoDating;
using UnityEngine;

public class Stickable : MonoBehaviour
{
    public static List<Stickable> currentTargets = new();
    public List<Stickable> debugList = new();

    private void Update()
    {
        debugList = currentTargets;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ItemDragDrop>(out ItemDragDrop item))
        {
            currentTargets.Add(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<ItemDragDrop>(out ItemDragDrop item))
        {
            foreach (Stickable stick in currentTargets)
            {
                if (this == stick)
                {
                    currentTargets.Remove(stick);
                    return;
                }
            }
        }
    }
    
    
}
