using UnityEngine.UI;
using UnityEngine;

public class PlayerMP : MonoBehaviour
{
    [SerializeField] bool MPOnOff = true;
    [SerializeField] bool muteki = default;
    [SerializeField] float m_heelmp = 0.1f;
    PlayerHP HP;
    //最大HPと現在のHP。
    public int maxMp = 100;
    [Range(0, 100)]
    public static float currentMp = 100f;
    //Sliderを入れる
    Image slider;

    void Start()
    {
        slider = GameObject.Find("内部ゲージ").GetComponent<Image>();

        if (PlayerHP.currentHp < 0)
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
        currentMp += m_heelmp;

        slider.fillAmount = (float)currentMp / (int)maxMp; ;

        if (currentMp >= maxMp)
        {
            currentMp = maxMp;
        }
    }
    public void UseMP(float mp)
    {
        if (!muteki)
        {
            currentMp -= mp;
            slider.fillAmount = (float)currentMp / (int)maxMp; ;
        }
    }
    public void FirstMP(float mp)
    {
            currentMp += mp;
            slider.fillAmount = (float)currentMp / (int)maxMp; ;
    }
}
