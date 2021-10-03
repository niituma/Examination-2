using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField] float Attacktime = 2.5f;
    [SerializeField] float Attackcooltime = 0f;
    [SerializeField] GameObject Bullet = default;
    [SerializeField] Transform Mazzle = default;
    [SerializeField] int deadpoint = 5;
    GameObject Player = default;
    int SHitpoint = 0;
    Animator m_anim = default;
    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Attackcooltime >= Attacktime)
        {
            m_anim.SetBool("PAttack", true);
            Attackcooltime = 0f;
        }
        else
        {
            m_anim.SetBool("PAttack", false);
        }
        if(SHitpoint >= deadpoint)
        {
            m_anim.SetBool("Dead", true);
        }
        EFlipx();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attackpoint"|| collision.tag == "Attackpoint2" || collision.tag == "Attackpoint3"|| collision.tag == "Skilpoint1" || collision.tag == "Skilpoint2" || collision.tag == "Skilpoint3")
        {
            SHitpoint += 1;
            m_anim.SetBool("P Hit", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_anim.SetBool("P Hit", false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "camera")
        {
            Attackcooltime += Time.deltaTime;
        }
    }
    void Firing()
    {
        Instantiate(Bullet, Mazzle.position, this.transform.rotation);
    }
    void EFlipx()
    {
        if (Player)
        { 
        if (this.transform.position.x > Player.transform.position.x)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (this.transform.position.x < Player.transform.position.x)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        }
    }
}
