using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int jumpCount = 0;
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool m_flipX = false;
    [SerializeField] public bool Guard = false;

    [SerializeField] GameObject Effect = default;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    private string grandTag = "Grand";
    public bool isGround = false;
    private Vector2 movement;
    Animator m_anim = default;
    Rigidbody2D rb = default;

    void Start()
    {
        m_anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");
        // 各種入力を受け取る
        Panch();
        Jump();
        JumpAttack();
        // 設定に応じて左右を反転させる
        if (m_flipX)
        {
            FlipX(m_h);
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
        if (collision.tag == grandTag)
        {
            isGround = true;
            jumpCount = 0;
        }
        if (collision.tag == "EAttack" && Guard == false)
        {
            m_anim.SetBool("Hit", true);
            Debug.Log("Hit!");
        }
        

        if (collision.tag == "EAttack" && Guard == true)
        {
            Vector3 hitPos = collision.bounds.ClosestPoint(this.transform.position);
            Instantiate(Effect, hitPos, Quaternion.identity);
            //エフェクト生成処理
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == grandTag)
        {
            isGround = false;
        }

        if (collision.tag == "EAttack")
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
        if (jumpCount < 2)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumpCount++;
                velocity.y = m_jumpPower;
                Debug.Log("ジャンプ");
            }
        }
        rb.velocity = velocity;
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

        if (Input.GetKey(KeyCode.S))
        {
            m_anim.SetBool("Gurad", true);
            Guard = true;
            Stopmove();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            m_anim.SetBool("Gurad", false);
            Guard = false;
            Removed();
        }
    }

    void Stopmove()
    {
        m_movePower = 0f;
    }
    void Removed()
    {
        m_movePower = 10f;
    }
    void Hitfalse()
    {
        m_anim.SetBool("Hit", false);
    }

}
