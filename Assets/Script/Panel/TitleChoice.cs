using UnityEngine;
using UnityEngine.UI;

public class TitleChoice : MonoBehaviour
{
    Button button;
    Button button2;

    void Start()
    {
        button = GameObject.Find("StartButton").GetComponent<Button>();
        button2 = GameObject.Find("CloseButton").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.D))
            button.Select();
        else if(Input.GetKey(KeyCode.A))
            button2.Select();
    }
}
