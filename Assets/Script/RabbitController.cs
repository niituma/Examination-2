using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{
    int Hitpoint;
    private string AttackTag = "Attackpoint";
    Animator m_anim = default;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Hitpoint == 3)
        {
            Destroy(this.GetComponent<Rabbitmove>());
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
        if (collision.tag == "camera")
        {
            m_anim.SetBool("Walk", true);
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
    void Destroy()
    {
        Destroy(this.gameObject);
    }
    
}

