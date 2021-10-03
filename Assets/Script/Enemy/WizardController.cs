using UnityEngine;

public class WizardController : MonoBehaviour
{
    /// <summary>弾が飛ぶ速さ</summary>
    [SerializeField] float m_speed = 3f;
    [SerializeField] float m_RSpeed = 3f;
    [SerializeField] float m_amplitube = 1.5f;
    [SerializeField] float m_speedY = 3f;
    [SerializeField] float Attackcooltime = 0f;
    [SerializeField] float Attacktime = 2.5f;
    [SerializeField] GameObject WBullet = default;
    [SerializeField] Transform WMazzle = default;
    /// <summary>移動先を示すアンカーポイント</summary>
    [Tooltip("移動先ターゲットとなるオブジェクト")]  // このように書くと Inspector に説明を表示できる
    [SerializeField] GameObject[] m_targets = default;
    /// <summary>ターゲットにこの距離まで近づいたら「到達した」と判断する距離（単位:メートル）</summary>
    [Tooltip("ターゲットに到達したと認識する距離")]
    [SerializeField] float m_stoppingDistance = 0.05f;
    [SerializeField] GameObject DeadWizard = default;
    [SerializeField] int deadpoint = 10;
    [SerializeField] GameObject WizardFile = default;
    int WHitpoint = 0;
    float Timer = 0f;
    int x = 0;
    float m_timer;
    GameObject Player = default;
    Vector2 m_initialpostion;
    Rigidbody2D m_rb = default;
    Animator m_anim = default;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_initialpostion = this.transform.position;
        Player = GameObject.FindGameObjectWithTag("Player");
        if (this.transform.position.x > m_targets[0].transform.position.x)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        if (this.transform.position.x < m_targets[0].transform.position.x)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        m_rb.velocity = new Vector2(0, Mathf.Sin(m_timer * m_speedY) * m_amplitube);
        Patrol();
        Attack();
        if (WHitpoint >= deadpoint)
        {
            Destroy(WizardFile.gameObject);
            Instantiate(DeadWizard, this.transform.position, this.transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Target1")
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }else if(collision.tag == "Target2")
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        if (collision.tag == "Attackpoint" || collision.tag == "Attackpoint2" || collision.tag == "Attackpoint3" || collision.tag == "Skilpoint1" || collision.tag == "Skilpoint2" || collision.tag == "Skilpoint3")
        {
            WHitpoint++;
            Debug.Log("W攻撃を受けた");
            m_anim.SetBool("W Hit", true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "camera")
        {
            EFlipx();
            m_speed = 0;
            m_anim.SetBool("W Idle", true);
            Attackcooltime += Time.deltaTime;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "camera")
        {
            m_anim.SetBool("W Idle", false);
        }
            m_anim.SetBool("W Hit", false);
        m_speed = m_RSpeed;
    }
    void EFlipx()
    {
        if (Player)
        {
            if (this.transform.position.x > Player.transform.position.x)
            {
                this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            }
            if (this.transform.position.x < Player.transform.position.x)
            {
                this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            }
        }
    }
    void Attack()
    {
        if (Attackcooltime >= Attacktime)
        {
            m_anim.SetBool("W Attack", true);
            Instantiate(WBullet, WMazzle.position, this.transform.rotation);
            Attackcooltime = 0f;
        }
        else
        {
            m_anim.SetBool("W Attack", false);
        }
    }
    void Patrol()
    {
        float distance = Vector2.Distance(this.transform.position, m_targets[x % m_targets.Length].transform.position);


        if (distance > m_stoppingDistance)  // ターゲットに到達するまで処理する
        {
            Vector3 dir = (m_targets[x % m_targets.Length].transform.position - this.transform.position).normalized * m_speed; // 移動方向のベクトルを求める
            this.transform.Translate(dir * Time.deltaTime); // Update の中で移動する場合は、Time.deltaTime をかけることによりどの環境でも同じ速さで移動させることができる
        }
        else
        {
            x = (x + 1) % m_targets.Length;
            Timer = 0;
        }
    }
}
