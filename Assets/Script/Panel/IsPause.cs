using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPause : MonoBehaviour
{
    Rigidbody2D m_rb = default;
    float m_angularVelocity;
    Vector2 m_velocity;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    public void Pause()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;

        if (gameObject.name == "Boss")
            GameObject.Find("Boss").GetComponent<BossController>().enabled = false;

        var objects = GameObject.FindObjectsOfType<WizardController>();
        var Wbullets = GameObject.FindObjectsOfType<WbulletMove>();
        var Lasers = GameObject.FindObjectsOfType<ParticleSystem>();

        foreach (var o in Lasers)
        {
            o.Pause();
        }
        foreach (var o in objects)
        {
            o.GetComponent<WizardController>().enabled = false;
        }

        foreach (var o in Wbullets)
        {
            o.GetComponent<WbulletMove>().enabled = false;
        }
        // 速度・回転を保存し、Rigidbody を停止する
        m_angularVelocity = m_rb.angularVelocity;
        m_velocity = m_rb.velocity;
        m_rb.Sleep();
        m_rb.simulated = false;
    }

    public void Resume()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;

        if (gameObject.name == "Boss")
            GameObject.Find("Boss").GetComponent<BossController>().enabled = true;

        var Lasers = GameObject.FindObjectsOfType<ParticleSystem>();
        var objects = GameObject.FindObjectsOfType<WizardController>();
        var Wbullets = GameObject.FindObjectsOfType<WbulletMove>();
        foreach (var o in Lasers)
        {
            o.Play();
        }
        foreach (var o in objects)
        {
            o.GetComponent<WizardController>().enabled = true;
        }
        foreach (var o in Wbullets)
        {
            o.GetComponent<WbulletMove>().enabled = true;
        }
        // Rigidbody の活動を再開し、保存しておいた速度・回転を戻す
        m_rb.simulated = true;
        m_rb.WakeUp();
        m_rb.angularVelocity = m_angularVelocity;
        m_rb.velocity = m_velocity;
    }
}
