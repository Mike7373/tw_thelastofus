using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishFight
{
    public class CharacterButton : MonoBehaviour
    {
        public void Select()
        {
            SceneManager.LoadScene("Fight");
        }
    }
}