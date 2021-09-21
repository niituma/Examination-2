using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    void Fadeout1()
    {
        SceneManager.LoadScene("Stage1");
    }
    void Fadeout2()
    {
        SceneManager.LoadScene("Stage2");
    }
    void Fadeout3()
    {
        SceneManager.LoadScene("Boss");
    }
}
