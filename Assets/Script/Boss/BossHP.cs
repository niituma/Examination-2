using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    //最大HPと現在のHP。
    float maxHp = 2000;
    float currentHp;
    [SerializeField] GameObject m_finishtimeline;
    //Sliderを入れる
    [SerializeField] Slider slider;
    private PlayerController Playercon;

    void Start()
    {
        slider.value = 1;
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);

    }

    private void Update()
    {
        if (slider?.value <= 0)
        {
            m_finishtimeline.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (slider)
        {
            //Enemyタグのオブジェクトに触れると発動
            if (collision.tag == "Attackpoint" || collision.tag == "Attackpoint2" || collision.tag == "Attackpoint3" || collision.tag == "Skilpoint1")
            {
                //ダメージは1～100の中でランダムに決める。
                int damage = Random.Range(1, 40);
                Debug.Log("damage : " + damage);

                //現在のHPからダメージを引く
                currentHp = currentHp - damage;
                Debug.Log("After currentHp : " + currentHp);

                //最大HPにおける現在のHPをSliderに反映。
                //int同士の割り算は小数点以下は0になるので、
                //(float)をつけてfloatの変数として振舞わせる。
                slider.value = (float)currentHp / (float)maxHp; ;
                Debug.Log("slider.value : " + slider.value);
            }
        }
    }
    public void HitLife(float life)
    {
            currentHp -= life;
            slider.value = (float)currentHp / (float)maxHp; ;
    }
}
