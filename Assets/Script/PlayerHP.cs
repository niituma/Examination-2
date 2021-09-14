using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] GameObject Deadplayer = default;
    [SerializeField] GameObject cameracollider = default;
    //最大HPと現在のHP。
    int maxHp = 155;
    int currentHp;
    //Sliderを入れる
    Slider slider;
    private PlayerController Playercon;

    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        Playercon = GetComponent<PlayerController>();
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }

    private void Update()
    {
        if(slider.value <= 0)
        {
            Destroy(cameracollider.GetComponent<BoxCollider2D>());
            Instantiate(Deadplayer, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter2D(Collider2D collision)
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