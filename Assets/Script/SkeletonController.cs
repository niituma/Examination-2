using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : Enemymove
{
    int SHitpoint = 0;
    [SerializeField] int deadpoint = 10;
    [SerializeField] float Attackcooltime = 0f;
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

        if (SHitpoint == deadpoint)
        {
            m_anim.SetBool("S Dead", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == AttackTag)
        {
            SHitpoint++;
            Debug.Log("攻撃を受けた");
            m_anim.SetBool("S Hit", true);
        }

        if (collision.gameObject.tag == "camera")
        {
            m_anim.SetBool("S Walk", true);
        }

        if (collision.tag == "Attackpoint")
        {
            if (this.transform.localScale.x > 0)
            {
                this.m_rb.AddForce(transform.right * 300f);
            }
            else
            {
                this.m_rb.AddForce(transform.right * -300f);
            }//向きでノックバック方向を判断
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_anim.SetBool("S Hit", false);
        if (collision.tag == "camera")
        {
            m_anim.SetBool("S Walk", false);
        }
    }
    private new void OnTriggerStay2D(Collider2D colltion)
    {
        base.OnTriggerStay2D(colltion);
        if (colltion.tag == "camera")
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
            m_anim.SetBool("S Attack", true);
            Attackcooltime = 0f;
        }
        else
        {
            m_anim.SetBool("S Attack", false);
        }
    }
}
