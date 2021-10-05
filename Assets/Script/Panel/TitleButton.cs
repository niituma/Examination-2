using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField] GameObject Panel = default;
    public void GameStart()
    {
        Panel.SetActive(true);
        StartCoroutine("NextStage");
    }

    public void GameClose()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif   
    }
    private IEnumerator NextStage()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Stage0");
    }
}
