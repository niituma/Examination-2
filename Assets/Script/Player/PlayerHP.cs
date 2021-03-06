using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] GameObject Deadplayer = default;
    [SerializeField] GameObject cameracollider = default;
    [SerializeField] bool HPOnOff = true;
    [SerializeField] bool mutekimode = default;
    [SerializeField] float _changeValueInterval = 0.5f;
    //最大HPと現在のHP。
    public float maxHp = 155;
    [Range(0, 155)]
    static public float currentHp = 155;
    public float Hp = 155;
    public bool playmuteki = default;
    //Sliderを入れる
    Slider slider;
    private PlayerController Playercon;

    void Start()
    {
        if (HPOnOff)
            slider = GameObject.Find("SliderHP").GetComponent<Slider>();

        if (currentHp < 0)
        {
            currentHp += maxHp;
            slider.value = 1;
        }

        if (slider)
        {
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
        
        if(currentHp >= maxHp)
        {
            currentHp = maxHp;
        }
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (slider && !mutekimode && !playmuteki)
        {
            //Enemyタグのオブジェクトに触れると発動
            if (collision.gameObject.tag == "EAttack" && !Playercon.Guard)
            {
                ////ダメージは1～100の中でランダムに決める。
                int damage = Random.Range(15, 21);
                Debug.Log("damage : " + damage);

                //現在のHPからダメージを引く
                currentHp = currentHp - damage;
                Debug.Log("After currentHp : " + currentHp);

                //最大HPにおける現在のHPをSliderに反映。
                //int同士の割り算は小数点以下は0になるので、
                //(float)をつけてfloatの変数として振舞わせる。
                //slider.value = (float)currentHp / (float)maxHp; ;
                ChangeValue((float)currentHp / (float)maxHp);
                //Debug.Log("slider.value : " + slider.value);
            }
        }
    }
    void ChangeValue(float value)
    {
        // DOTween.To() を使って連続的に変化させる
        DOTween.To(() => slider.value, x => slider.value = x, value, _changeValueInterval)  .OnComplete(() => Debug.Log($"lifeが{value}になりました"));

    }
    public void HitPoisonLife(float life)
    {
        if (!mutekimode || !playmuteki)
        {
            currentHp -= life * Time.deltaTime;
            slider.value = (float)currentHp / (float)maxHp; ;
        }
    }
    public void HitLife(float life)
    {
        if (!mutekimode|| !playmuteki)
        {
            currentHp -= life;
            slider.value = (float)currentHp / (float)maxHp; ;
        }
    }
    public void AddLife(float life)
    {
        currentHp += life;
        slider.value = (float)currentHp / (float)maxHp; ;
    }
}