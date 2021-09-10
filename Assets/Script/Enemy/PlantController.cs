using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField] float Attacktime = 2.5f;
    [SerializeField] float Attackcooltime = 0f;
    [SerializeField] GameObject Bullet = default;
    [SerializeField] Transform Mazzle = default;
    [SerializeField] public GameObject Player = default;
    Animator m_anim = default;
    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
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
        EFlipx();
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
