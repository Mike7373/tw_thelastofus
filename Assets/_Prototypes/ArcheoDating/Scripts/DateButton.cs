using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArcheoDating
{
    public class DateButton : MonoBehaviour
    {
        public void Date()
        {
            SceneManager.LoadScene("DateScene");
        }
    }
}
