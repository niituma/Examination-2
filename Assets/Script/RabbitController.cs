﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{
    int Hitpoint;
    [SerializeField]float Attackcooltime = 0f;
    public bool cooltime = true;
    [SerializeField] GameObject Player = default;
    private string AttackTag = "Attackpoint";
    Animator m_anim = default;


    private void Start()
    {
        m_anim = GetComponent<Animator>();
    }
    private void Update()
    {
        EFlipx();
        Attack();
        if (Hitpoint == 3)
        {
            m_anim.SetBool("Dead", true);
        }
        //if (cooltime == true)
        //{
        //    Attackcooltime += Time.deltaTime; 
        //}

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
        Vector2 PoseA = Player.transform.position;
        Vector2 PoseB = this.transform.position;
        float dis = Vector2.Distance(PoseA, PoseB);
        if (dis <= 4f && Attackcooltime >= 1.5f)
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

