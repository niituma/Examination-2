using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] float m_attacktime = 5f;
    [SerializeField] float m_dis = 0;
    [SerializeField] float m_attackareadis = 5f;
    GameObject Player = default;
    float m_attack1cooltime = 0;
    Animator m_anim = default;
    Rigidbody2D m_rb = default;

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PoseA = (Vector2)(Player?.transform.position);
        Vector3 PoseB = this.transform.position;
        m_dis = Vector2.Distance(PoseA, PoseB);
        Attack1();
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
        if (m_dis <= m_attackareadis && m_attack1cooltime >= m_attacktime)
        {
            m_anim.SetBool("Attack1", true);
            m_attack1cooltime = 0f;
        }
        else
        {
            m_anim.SetBool("Attack1", false);
        }
    }
}
