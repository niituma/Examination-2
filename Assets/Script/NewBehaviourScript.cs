using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
    private Vector2 movement;
    Animator m_anim = default;
    // Start is called before the first frame update
    void Start()
    {
        m_h = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(m_movePower * m_h, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("ここにジャンプする処理を書く。");

        }
    }
}
