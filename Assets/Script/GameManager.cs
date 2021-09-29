using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public int m_gameovercount = 0;
    static public int m_sceancount = 3;
    bool ispause = default;
    GameObject Player;
    private void Start()
    {
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
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
    void PauseResume()
    {
        ispause = !ispause;

        // 全ての GameObject を取ってきて、IPause を継承したコンポーネントが追加されていたら Pause または Resume を呼ぶ
        var objects = FindObjectsOfType<GameObject>();

        foreach (var o in objects)
        {
            IsPause i = o.GetComponent<IsPause>();

            if (ispause)
            {
                i?.Pause();     // ここで「多態性」が使われている
            }
            else
            {
                i?.Resume();    // ここで「多態性」が使われている
            }
        }
        if (ispause)
        {
            FindObjectOfType<Pauser>().Pause();
        }
        else
        {
            FindObjectOfType<Pauser>().Resume();
        }
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
