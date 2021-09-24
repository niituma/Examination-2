using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwhitcher : MonoBehaviour
{
    GameObject m_player;
    GameObject m_HP;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_HP = GameObject.Find("DDOL");
    }
    public void TurnOff()
    {
        if (m_player)
        {
            m_player.SetActive(false);
            if (m_HP)
                m_HP.SetActive(false);
        }
    }
    public void TurnOn()
    {
        if (m_player)
        {
            m_player.SetActive(true);
            if (m_HP)
                m_HP.SetActive(true);
        }
    }
}
