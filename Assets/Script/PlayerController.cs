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
    Rigidbody2D rb = default;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    float m_scaleX;
    private string grandTag = "Grand";
    public bool isGrand = false;
    public bool Down = false;
    private Vector2 movement;
    Animator m_anim = default;

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
        Jump();
        Panch();
        // 設定に応じて左右を反転させる
        if (m_flipX)
        {
            FlipX(m_h);
        }
    }
    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        rb.velocity = new Vector2(m_movePower * m_h, rb.velocity.y);
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            m_anim.SetBool("Run", true);
        }
        else if (isGrand == false || Input.GetAxisRaw("Horizontal") == 0)
        {
            m_anim.SetBool("Run", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Down = false;
        if (collision.tag == grandTag)
        {
            isGrand = true;
            jumpCount = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Down = true;
        if (collision.tag == grandTag && jumpCount == 2)
        {
            isGrand = false;
        }
        m_anim.SetBool("Jump", true);
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
        m_scaleX = this.transform.localScale.x;

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
        if (jumpCount <= 1)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrand)
                {
                    jumpCount++;
                    rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
                    Debug.Log("ここにジャンプする処理を書く。");
                }
            }
        }
        if (Down == true)
        {
            m_anim.SetBool("Jump", true);
        }
        else
        {
            m_anim.SetBool("Jump", false);
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_anim.SetBool("Down Nomal Attack", true);
        }
        else
        {
            m_anim.SetBool("Down Nomal Attack", false);
        }
    }

    void Stopmove()
    {
        m_movePower = 0;
    }
    void Removed()
    {
        m_movePower = 10;
    }

}
