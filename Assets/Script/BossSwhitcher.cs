using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwhitcher : MonoBehaviour
{
     [SerializeField] GameObject m_boss;
    // Start is called before the first frame update
    void Start()
    {
        m_boss = GameObject.FindGameObjectWithTag("Boss");
    }
    public void TurnOff()
    {
        if (m_boss)
            m_boss.SetActive(false);
    }
    public void TurnOn()
    {
        if (m_boss)
            m_boss.SetActive(true);
    }
}
