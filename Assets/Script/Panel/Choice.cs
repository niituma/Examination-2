using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GameObject.Find("BackButton").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }
}
