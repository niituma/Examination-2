using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    void Fadeout()
    {
        SceneManager.LoadScene("Stage2");
    }
}
