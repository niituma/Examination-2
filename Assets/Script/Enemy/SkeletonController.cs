using System.Collections;
using UnityEngine;

public class SkeletonController : Enemybasemove
{
    int SHitpoint = 0;
    [SerializeField] float Attacktime = 2.5f;
    [SerializeField] int deadpoint = 10;
    [SerializeField] float Attackcooltime = 0f;
    [SerializeField] GameObject Item = default;
    [SerializeField] float knockbackForce = 0.5f;
    GameObject aftereff = default;
    private string AttackTag = "Attackpoint";
    private Vector2 knockbackVelocity = Vector2.zero;
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

        if (SHitpoint >= deadpoint)
        {
            aftereff = GameObject.Find(this.gameObject.name + "AfterImageEffect");
            if(aftereff != null)
            Destroy(aftereff.gameObject);

            m_anim.SetBool("S Dead", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attackpoint" || collision.tag == "Attackpoint2" || collision.tag == "Attackpoint3" || collision.tag == "Skilpoint1" || collision.tag == "Skilpoint2")
        {
            SHitpoint++;
            Debug.Log("攻撃を受けた");
            m_anim.SetBool("S Hit", true);
        }

        if (collision.gameObject.tag == "camera")
        {
            m_anim.SetBool("S Walk", true);
        }

        if (collision.tag == "Attackpoint2" || collision.tag == "Skilpoint1")
        {
            if (this.transform.localScale.x > 0)
            {
                m_rb.velocity = (transform.right * knockbackForce);
                StartCoroutine("Knockback");
            }
            else
            {
                m_rb.velocity = (transform.right * -knockbackForce);
                StartCoroutine("Knockback");
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
    public override void Activate()
    {
        Instantiate(Item, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void Attack()
    {

        if (dis <= Stopdis && Attackcooltime >= Attacktime)
        {
            m_anim.SetBool("S Attack", true);
            Attackcooltime = 0f;
        }
        else
        {
            m_anim.SetBool("S Attack", false);
        }
    }
    private IEnumerator Knockback()
    {
        yield return new WaitForSeconds(0.5f);
        m_rb.velocity = Vector2.zero;
    }
}
