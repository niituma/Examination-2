using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwhitcher : MonoBehaviour
{
    GameObject m_player;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }
    public void TurnOff()
    {
        if (m_player)
            m_player.SetActive(false);
    }
    public void TurnOn()
    {
        if (m_player)
            m_player.SetActive(true);
    }
}
