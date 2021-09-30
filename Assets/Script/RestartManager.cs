using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartManager : MonoBehaviour
{
    static public int m_gameovercount = 0;
    static public int m_sceancount = 3;
    bool ispause = default;
    GameObject Player;
    private void Start()
    {
        Player = GameObject.Find("Player");
    }
    
    public void SceanCount(int count)
    {
        m_sceancount = count;
    }
    void PlayerDead()
    {
        m_gameovercount++;
        StartCoroutine(ReStart());
    }
    IEnumerator ReStart()
    {
        if (m_gameovercount > 3)
        {
            yield return new WaitForSeconds(0.3f);
            SceneManager.LoadScene(0);
        }
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(m_sceancount);
    }
}
