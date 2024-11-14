using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(DialogueBrain))]
public class DialogueActor : MonoBehaviour
{
    #region Fields

    [HorizontalGroup("ActorData", 100)] [PreviewField(100)] [HideLabel] [SerializeField]
    protected Sprite _icon;

    [VerticalGroup("ActorData/Info")] [LabelWidth(100)] [SerializeField]
    protected string _actorName;

    [VerticalGroup("ActorData/Info")] [LabelWidth(100)] [SerializeField]
    protected ActorType _actorType;

    [VerticalGroup("ActorData/Info")] [LabelWidth(100)] [SerializeField]
    protected string _actorID;

    [VerticalGroup("ActorData/Info")] [LabelWidth(100)] [SerializeField]
    protected bool _isPlayer;

    [VerticalGroup("ActorData/Info")] [LabelWidth(100)] [SerializeField] 
    protected SpriteRenderer _interactionImg;
    
    [VerticalGroup("ActorData/Info")] [LabelWidth(100)] [SerializeField] 
    protected Collider _actorRange;

    public bool IsPlayer
    {
        get { return _isPlayer; }
    }
    protected static List<DialogueActor> _actorInstances = new();
    protected static DialogueActor _currentInteractionActor;

    #endregion

    #region Properties

    public Sprite Icon
    {
        get { return _icon; }
    }

    public string ActorName
    {
        get { return _actorName; }
    }

    public string ActorID
    {
        get { return _actorID; }
    }

    public static DialogueActor PlayerActor { get; private set; }

    #endregion

    private void Awake()
    {
        _actorInstances.Add(this);
        if (_isPlayer)
        {
            if (PlayerActor == null)
            {
                PlayerActor = this;
            }
            else
            {
                Debug.LogWarning(
                    $"[DialogueActor] -> There are more than one DialogueActor with isPlayer flag setted on true.");
            }
        }
    }

    private void Start()
    {
        if (_interactionImg != null)
        {
            _interactionImg.enabled = false;
        }
    }

    /// <summary>
    /// Restituisce l'istanza dell'actor a cui appartiene l'id passato come parametro
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static DialogueActor FindActorByID(string id)
    {
        foreach (DialogueActor actor in _actorInstances)
        {
            if (actor._actorID == id)
            {
                return actor;
            }
        }

        Debug.LogWarning($"[DialogueActor] FindActorByID is returning a null value! ID:{id} can't be found.");
        return null;
    }

    /// <summary>
    /// Inizia un dialgo con i dati presenti nel brain
    /// </summary>
    public void Interact(InputAction.CallbackContext callbackContext)
    {
        if (_currentInteractionActor != null)
        {
            _currentInteractionActor.GetComponent<DialogueBrain>().StartDialogue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<DialogueActor>(out DialogueActor actor))
        {
            if (actor._isPlayer)
            {
                _interactionImg.enabled = true;
                _currentInteractionActor = this;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<DialogueActor>(out DialogueActor actor))
        {
            if (actor._isPlayer)
            {
                _interactionImg.enabled = false;
                _currentInteractionActor = null;
            }
        }
        if (other.TryGetComponent<FightTower>(out FightTower tower))
        {
            _interactionImg.enabled = false;
        }
    }
}