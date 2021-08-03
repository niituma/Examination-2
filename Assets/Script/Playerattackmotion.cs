using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattackmotion : MonoBehaviour
{
    Animator m_anim = default;
    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Panch();
    }
     void Panch()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            m_anim.SetBool("Punch", true);
        }
        else
        {
            m_anim.SetBool("Punch", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_anim.SetBool("Down Nomal Attack", true);
        }
        else
        {
            m_anim.SetBool("Down Nomal Attack", false);
        }
    }
}
