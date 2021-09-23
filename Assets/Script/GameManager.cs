using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public int m_gameovercount = 0;
    static public int m_sceancount = 3;
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
