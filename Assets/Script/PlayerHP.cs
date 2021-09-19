using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] GameObject Deadplayer = default;
    [SerializeField] GameObject cameracollider = default;
    [SerializeField] bool muteki = default;
    //最大HPと現在のHP。
    float maxHp = 155;
    static public float currentHp = 155;
    //Sliderを入れる
    Slider slider;
    private PlayerController Playercon;

    void Start()
    {
        if (slider)
        {
            slider = GameObject.Find("Slider").GetComponent<Slider>();
            Playercon = GetComponent<PlayerController>();
            Debug.Log("Start currentHp : " + currentHp);
        }
    }

    private void Update()
    {
        if (slider?.value <= 0)
        {
            Destroy(cameracollider.GetComponent<BoxCollider2D>());
            Instantiate(Deadplayer, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (slider&&!muteki)
        {
            //Enemyタグのオブジェクトに触れると発動
            if (collision.gameObject.tag == "EAttack" && !Playercon.Guard)
            {
                //ダメージは1～100の中でランダムに決める。
                int damage = Random.Range(1, 50);
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
        if (!muteki)
        {
        currentHp -= life * Time.deltaTime;
        slider.value = (float)currentHp / (float)maxHp; ;
        }
    }
}