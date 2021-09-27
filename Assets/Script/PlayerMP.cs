using UnityEngine.UI;
using UnityEngine;

public class PlayerMP : MonoBehaviour
{
    [SerializeField] bool MPOnOff = true;
    [SerializeField] bool muteki = default;
    PlayerHP HP;
    //最大HPと現在のHP。
    public int maxMp = 100;
    [Range(0, 100)]
    static public float currentMp = 100f;
    //Sliderを入れる
    Image slider;

    void Start()
    {
            slider = GameObject.Find("内部ゲージ").GetComponent<Image>();

        if (HP?.Hp < 0)
        {
            currentMp += maxMp;
            slider.fillAmount = 1f;
        }

        if (slider)
        {
            Debug.Log("Start currentMp : " + currentMp);
        }
    }

    private void Update()
    {
        if (currentMp >= maxMp)
        {
            currentMp = maxMp;
        }
        if (Input.GetButtonDown("Fire2") && !muteki)
        {
            float usingmp = 10f;
            Debug.Log("damage : " + usingmp);

            //現在のHPからダメージを引く
            currentMp = currentMp - usingmp;
            Debug.Log("After currentMp : " + currentMp);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.fillAmount = (float)currentMp / (int)maxMp;
            Debug.Log("slider.value : " + slider.fillAmount);
        }
    }
    public void UseMP(float mp)
    {
        if (!muteki)
        {
            currentMp -= mp;
            slider.fillAmount = (float)currentMp / (float)maxMp; ;
        }
    }
}
