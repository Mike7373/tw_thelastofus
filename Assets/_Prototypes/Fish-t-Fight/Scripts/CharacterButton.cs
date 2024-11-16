using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterButton : MonoBehaviour
{
    public void Select()
    {
        SceneManager.LoadScene("Fight");
    }
}
