using UnityEngine;
using UnityEngine.SceneManagement;

public class DateManager : MonoBehaviour
{
    public DialogueBrain Brain; 
    
    private void Start()
    {
        Brain.StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("DateScene");
        }
    }
}
