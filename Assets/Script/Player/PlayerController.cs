using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int jumpCount = 0;
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>再度移動する力/// </summary>
    float m_removePower = 0;
    /// <summary>バックステップする力/// </summary>
    [SerializeField] float m_backForce = 50f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool m_flipX = false;
    [SerializeField] public bool Guard = false;
    /// <summary>壁を検出するための ray のベクトル</summary>
    [SerializeField] Vector2 m_rayForWall = Vector2.zero;
    /// <summary>壁のレイヤー（レイヤーはオブジェクトに設定されている）</summary>
    [SerializeField] LayerMask m_wallLayer = 0;

    [SerializeField] GameObject Effect = default;
    [SerializeField] Transform JumpAura = default;
    [SerializeField] GameObject JumpEffect = default;
    [SerializeField] Transform skill2mazulle = default;
    [SerializeField] GameObject skill2Effect = default;
    [SerializeField] Transform skill3mazulle = default;
    [SerializeField] GameObject skill3Effect = default;
    [SerializeField] AudioSource HitAudio;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    bool breakGuard = default;
    bool isback = default;
    private string grandTag = "Grand";
    public bool isGround = true;
    private Vector2 movement;
    PlayerHP HP;
    PlayerSP SP;
    Animator m_anim = default;
    Rigidbody2D rb = default;

    void Start()
    {
        HP = GetComponent<PlayerHP>();
        SP = GetComponent<PlayerSP>();
        m_anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        m_removePower = m_movePower;
    }

    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");
        // 各種入力を受け取る
        Panch();
        Skill();
        Jump();
        JumpAttack();
        BackStep();

        if (PlayerSP.currentSp < 0)
            breakGuard = true;
        else if (PlayerSP.currentSp >= SP.maxSp)
            breakGuard = false;

        // 設定に応じて左右を反転させる
        if (m_flipX)
        {
            FlipX(m_h);
        }

        if (isback)
        {
            if (this.transform.localScale.x > 0)
                rb.AddForce(transform.right * -1 * m_backForce, ForceMode2D.Force);
            if (this.transform.localScale.x < 0)
                rb.AddForce(transform.right * m_backForce, ForceMode2D.Force);
        }

        Vector2 origin = new Vector2(transform.position.x, transform.position.y + 1f);   // origin は「raycast の始点」である
        Debug.DrawLine(origin, origin + m_rayForWall, Color.red);  // ray（光線）を Scene 上に描く
        // Raycast して壁の検出を試みる
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, m_rayForWall, m_rayForWall.magnitude, m_wallLayer);   // hit には ray の衝突情報が入っている
        if (hit.collider)  // hit.collider は「ray が衝突した collider」が入っている。ray が何にもぶつからなかったら null である。
        {
            isGround = true;
            jumpCount = 0;
        }
        else
        {
            isGround = false;
        }
    }

    private void LateUpdate()
    {
        if (m_anim)
        {
            m_anim.SetFloat("SpeedY", rb.velocity.y);
            m_anim.SetBool("isGround", isGround);
        }
    }
    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        rb.velocity = new Vector2(m_movePower * m_h, rb.velocity.y);
        if (Input.GetAxisRaw("Horizontal") != 0 && isGround)
        {
            m_anim.SetBool("Run", true);
        }
        else if (!isGround || Input.GetAxisRaw("Horizontal") == 0)
        {
            m_anim.SetBool("Run", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EAttack" && Guard == false && !HP.playmuteki|| collision.tag == "BAttack" && !HP.playmuteki)
        {
            m_anim.SetBool("Hit", true);
            HitAudio.PlayOneShot(HitAudio.clip);
            Debug.Log("Hit!");
        }
        else if (collision.tag == "BAttack" && Guard == true)
        {
            m_anim.SetBool("Hit", true);
            HitAudio.PlayOneShot(HitAudio.clip);
        }


        if (collision.tag == "EAttack" && Guard)
        {
            Vector3 hitPos = collision.bounds.ClosestPoint(this.transform.position);
            Instantiate(Effect, hitPos, Quaternion.identity);
            //エフェクト生成処理
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EAttack" || collision.tag == "BAttack")
        {
            m_anim.SetBool("Hit", false);
        }
    }

    /// <summary>
    /// 左右を反転させる
    /// </summary>
    /// <param name="horizontal">水平方向の入力値</param>
    void FlipX(float horizontal)
    {
        /*
         * 左を入力されたらキャラクターを左に向ける。
         * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
         * Sprite Renderer の Flip:X を操作しても反転する。
         * */

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    void Jump()
    {
        Vector2 velocity = rb.velocity;
        if (jumpCount < 1)
        {
            if (Input.GetButtonDown("Jump") && !Guard)
            {
                Instantiate(JumpEffect, JumpAura.position, this.transform.rotation);
                jumpCount++;
                velocity.y = m_jumpPower;
                Debug.Log("ジャンプ");
            }
        }
        rb.velocity = velocity;
    }
    void BackStep()
    {
        if (Input.GetButtonDown("Debug Multiplier"))
        {
            m_anim.SetBool("BackStep", true);
        }
        else
        {
            m_anim.SetBool("BackStep", false);
        }
    }
    void GoBack()
    {
        if (!isback)
        {
            isback = true;
            HP.playmuteki = true;
        }
        else
        {
            isback = false;
            HP.playmuteki = false;
        }
    }

    void JumpAttack()
    {
        if (!isGround && Input.GetButtonDown("Fire1"))
        {
            m_anim.SetBool("Jump Attack", true);
        }
        else
        {
            m_anim.SetBool("Jump Attack", false);
        }
    }

    void Panch()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            m_anim.SetBool("Punch", true);
        }
        else
        {
            m_anim.SetBool("Punch", false);
        }

        if (Input.GetKey(KeyCode.S) && isGround && PlayerSP.currentSp > 0 && !breakGuard)
        {
            m_anim.SetBool("Gurad", true);
            Guard = true;
            Stopmove();
        }
        else if (Input.GetKeyUp(KeyCode.S) || PlayerSP.currentSp < 0)
        {
            m_anim.SetBool("Gurad", false);
            Guard = false;
            Removed();
        }
    }
    void Skill()
    {
        if (Input.GetButtonDown("Fire2") && PlayerMP.currentMp > 0)
        {
            m_anim.SetBool("Skill", true);
        }
        else
        {
            m_anim.SetBool("Skill", false);
        }
    }
    void Skill2Ability()
    {
        Instantiate(skill2Effect, skill2mazulle.position, skill2mazulle.transform.rotation);
    }
    void Skill3Ability()
    {
        Instantiate(skill3Effect, skill3mazulle.position, this.transform.rotation);
    }
    void SkillMP()
    {
        float m_skillusemp = 10f;
        FindObjectOfType<PlayerMP>().UseMP(m_skillusemp);
    }
    void Stopmove()
    {
        m_movePower = 0f;
    }
    void Removed()
    {
        m_movePower = m_removePower;
    }
    void Hitfalse()
    {
        m_anim.SetBool("Hit", false);
    }

}
