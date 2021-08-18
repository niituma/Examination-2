using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{
    int Hitpoint;
    [SerializeField] float m_Speed = 3;
    private string AttackTag = "Attackpoint";
    [SerializeField] GameObject Player = default;
    Animator m_anim = default;
    Rigidbody2D m_rb = default;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Hitpoint==3)
        {
            m_anim.SetBool("Dead", true);
        }
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y), m_Speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == AttackTag)
        {
            Hitpoint++;
            Debug.Log("攻撃を受けた");
            m_anim.SetBool("Hit", true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_anim.SetBool("Hit", false);
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}

