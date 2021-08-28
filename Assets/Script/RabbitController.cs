using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{
    int Hitpoint = 0;
    [SerializeField] int deadpoint = 10;
    float dis = 0;
    [SerializeField] float m_Speed = 4f;
    [SerializeField]float Attackcooltime = 0f;
    public bool cooltime = true;
    [SerializeField] GameObject Player = default;
    private string AttackTag = "Attackpoint";
    Animator m_anim = default;
    Rigidbody2D m_rb = default;


    private void Start()
    {
        m_anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 PoseA = Player.transform.position;
        Vector2 PoseB = this.transform.position;
        dis = Vector2.Distance(PoseA, PoseB);

        EFlipx();
        Attack();

        if (Hitpoint == deadpoint)
        {
            m_anim.SetBool("Dead", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == AttackTag)
        {
            Hitpoint++;
            Debug.Log("攻撃を受けた");
            m_anim.SetBool("Hit", true);
        }

        if (collision.gameObject.tag == "camera")
        {
            m_anim.SetBool("Walk", true);
        }

        if (collision.tag == "Attackpoint")
        {
            if (this.transform.localScale.x > 0)
            {
                this.m_rb.AddForce(transform.right * 3000f);
            }
            else
            {
                this.m_rb.AddForce(transform.right * -3000f);
            }//向きでノックバック方向を判断
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_anim.SetBool("Hit", false);
        if (collision.tag == "camera")
        {
            m_anim.SetBool("Walk", false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "camera")
        {
            Attackcooltime += Time.deltaTime;
        }
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
    
    void EFlipx()
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
    void Attack()
    {
        
        if (dis <= 3f && Attackcooltime >= 1.5f)
        {
            m_anim.SetBool("Attack", true);
            Attackcooltime = 0f;
            cooltime = true;
        }
        else
        {
            m_anim.SetBool("Attack", false);
        }
    }
}

