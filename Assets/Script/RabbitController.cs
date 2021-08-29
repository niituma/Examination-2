using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : Enemymove
{
    int Hitpoint = 0;
    [SerializeField] int deadpoint = 10;
    [SerializeField] float Attackcooltime = 0f;
    public bool cooltime = true;
    private string AttackTag = "Attackpoint";
    Animator m_anim = default;
    Rigidbody2D m_rb = default;


    private void Start()
    {
        m_anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
    }
    private new void Update()
    {
        base.Update();
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
    private new void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        if (collision.tag == "camera")
        {
            Attackcooltime += Time.deltaTime;
        }
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }

    void Attack()
    {

        if (dis <= 3f && Attackcooltime >= 2.5f)
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

