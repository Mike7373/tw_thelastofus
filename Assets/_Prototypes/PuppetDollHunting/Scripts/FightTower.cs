using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FightTower : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _excPoint;
    private bool _isTriggered;

    private void Start()
    {
        _excPoint.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DialogueActor>(out DialogueActor actor) && actor.IsPlayer)
        {
            _excPoint.enabled = true;
            _isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<DialogueActor>(out DialogueActor actor) && actor.IsPlayer)
        {
            _excPoint.enabled = false;
            _isTriggered = false;
        }
    }

    public void Interact(InputAction.CallbackContext callbackContext)
    {
        if (_isTriggered)
        {
            SceneManager.LoadScene("Combat");
        }
    }
}
