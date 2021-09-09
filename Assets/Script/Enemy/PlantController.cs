using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField] float Attacktime = 2.5f;
    [SerializeField] float Attackcooltime = 0f;
    [SerializeField] GameObject Bullet = default;
    [SerializeField] Transform Mazzle = default;
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
}
