using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] float m_attack1time = 5f;
    [SerializeField] float m_attack23time = 20f;
    [SerializeField] float m_dis = 0;
    [SerializeField] float m_attackareadis = 5f;
    [SerializeField] float m_attack1cooltime = 0;
    [SerializeField] float m_attack23cooltime = 0;
    [SerializeField] float attack3movespeed = 0.5f;
    [SerializeField] float attack2movespeed = 5f;
    [SerializeField] GameObject m_laser = default;
    GameObject Attack2pos = default;
    GameObject Player = default;
    bool Skill = default;
    bool ismoving2 = default;
    bool ismoving3 = default;
    Vector2 pos;
    Animator m_anim = default;
    Rigidbody2D m_rb = default;

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        Attack2pos = GameObject.Find("Attack2Pos");
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PoseA = (Vector2)(Player?.transform.position);
        Vector3 PoseB = this.transform.position;
        m_dis = Vector2.Distance(PoseA, PoseB);


        if (!Skill)
            m_attack23cooltime += Time.deltaTime;

        if (ismoving3)
            this.gameObject.transform.position = new Vector2(this.transform.position.x - attack3movespeed, this.transform.position.y);

        if (ismoving2)
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(Attack2pos.transform.position.x, Attack2pos.transform.position.y + 3), attack2movespeed * Time.deltaTime);


        Attack1();
        Attack23();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "camera")
        {
            m_attack1cooltime += Time.deltaTime;
        }
    }

    void Attack1()
    {
        if (m_dis <= m_attackareadis && m_attack1cooltime >= m_attack1time)
        {
            m_anim.SetBool("Attack1", true);
            m_attack1cooltime = 0f;
        }
        else
        {
            m_anim.SetBool("Attack1", false);
        }
    }
    void Attack23()
    {
        if (m_attack23cooltime >= m_attack23time)
        {
            Skill = true;
            m_attack23cooltime = 0f;
            int Attack = Random.Range(1, 3);
            if (Attack == 1)
            {
                ismoving2 = true;
                m_anim.SetBool("Attack2", true);
            }
            else
            {
                m_anim.SetBool("Attack3", true);
                transform.Rotate(new Vector3(0, 0, 90));
                ismoving3 = true;
            }
        }
        else
        {
            m_anim.SetBool("Attack2", false);
            m_anim.SetBool("Attack3", false);
        }
    }
    void Skillfalse()
    {
        Skill = false;
    }
    void AttackMovefalse()
    {
        ismoving2 = false;
        ismoving3 = false;
    }
    void Attack3Rerotate()
    {
        transform.Rotate(new Vector3(0, 0, -90));
    }
    void LaserOn()
    {
        m_laser.SetActive(true);
    }
    void LaserOff()
    {
        m_laser.SetActive(false);
    }
}
