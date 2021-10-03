using System.Collections;
using UnityEngine;

public class RabbitController : Enemybasemove
{
    int RHitpoint = 0;
    [SerializeField] float Attacktime = 2.5f;
    [SerializeField] int deadpoint = 10;
    [SerializeField] float Attackcooltime = 0f;
    [SerializeField] GameObject Item = default;
    [SerializeField] float knockbackForce = 0.5f;
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

        if (RHitpoint >= deadpoint)
        {
            m_anim.SetBool("Dead", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attackpoint" || collision.tag == "Attackpoint2" || collision.tag == "Attackpoint3" || collision.tag == "Skilpoint1" || collision.tag == "Skilpoint2" || collision.tag == "Skilpoint3")
        {
            RHitpoint++;
            Debug.Log("攻撃を受けた");
            m_anim.SetBool("Hit", true);
        }

        if (collision.gameObject.tag == "camera")
        {
            m_anim.SetBool("Walk", true);
        }

        if (collision.tag == "Attackpoint2" || collision.tag == "Skilpoint1")
        {
            if (this.transform.localScale.x > 0)
            {
                this.m_rb.AddForce(transform.right * knockbackForce);
                StartCoroutine("Knockback");
            }
            else
            {
                this.m_rb.AddForce(transform.right * -knockbackForce);
                StartCoroutine("Knockback");
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

    public override void Activate()
    {
        //Debug.Log("Rabbitが近づいている！");
        Instantiate(Item, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void Attack()
    {

        if (dis <= Stopdis && Attackcooltime >= Attacktime)
        {
            m_anim.SetBool("Attack", true);
            Attackcooltime = 0f;
        }
        else
        {
            m_anim.SetBool("Attack", false);
        }
    }
    private IEnumerator Knockback()
    {
        yield return new WaitForSeconds(0.5f);
        m_rb.velocity = Vector2.zero;
    }
}

