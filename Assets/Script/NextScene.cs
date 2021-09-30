using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] GameObject Pausepanel = default;
    public void FadeoutTitle()
    {
        SceneManager.LoadScene("Title");
    }
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
    void PausePanelOn()
    {
        Pausepanel.SetActive(true);
    }
    void PausePanelOff()
    {
        Pausepanel.SetActive(false);
    }
}
