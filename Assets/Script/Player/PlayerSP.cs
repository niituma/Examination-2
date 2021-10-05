using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class PlayerSP : MonoBehaviour
{
    [SerializeField] bool HPOnOff = true;
    [SerializeField] bool muteki = default;
    [SerializeField] float m_heelsp = 0.8f;
    bool isheelsp = default;
    //最大SPと現在のSP。
    public float maxSp = 50;
    [Range(0, 155)]
    static public float currentSp = 50;
    //Sliderを入れる
    Slider slider;
    private PlayerController Playercon;

    void Start()
    {
        if (HPOnOff)
            slider = GameObject.Find("SliderSP").GetComponent<Slider>();

        if (PlayerHP.currentHp <= 0)
        {
            currentSp += maxSp;
            slider.value = 1;
        }

        if (slider)
        {
            Playercon = GetComponent<PlayerController>();
            Debug.Log("Start currentSp : " + currentSp);
        }
    }

    private void Update()
    {
        if (isheelsp && !Playercon.Guard)
        {
            currentSp += m_heelsp;

            slider.value = (float)currentSp / (float)maxSp; ;
        }

        if (currentSp >= maxSp)
        {
            currentSp = maxSp;
            isheelsp = false;
        }
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (slider && !muteki)
        {
            //Enemyタグのオブジェクトに触れると発動
            if (collision.gameObject.tag == "EAttack" && Playercon.Guard)
            {
                //ダメージは1～100の中でランダムに決める。
                int damage = Random.Range(10, 15);
                Debug.Log("damage : " + damage);

                //現在のHPからダメージを引く
                currentSp = currentSp - damage;
                Debug.Log("After currentSp : " + currentSp);

                //最大HPにおける現在のHPをSliderに反映。
                //int同士の割り算は小数点以下は0になるので、
                //(float)をつけてfloatの変数として振舞わせる。
                slider.value = (float)currentSp / (float)maxSp; ;
                Debug.Log("slider.value : " + slider.value);
                StartCoroutine(HeelSPStart());
            }
        }
    }
    IEnumerator HeelSPStart()
    {
        yield return new WaitForSeconds(1f);
        isheelsp = true;
    }
}
