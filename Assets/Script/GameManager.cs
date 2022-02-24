using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //
    [SerializeField] GameObject PausePanel = default;
    bool ispause = default;
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
    }
    public void PauseResume()
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
                PausePanel.SetActive(true);
                Cursor.visible = true;
            }
            else
            {
                i?.Resume();    // ここで「多態性」が使われている
                PausePanel.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
}
