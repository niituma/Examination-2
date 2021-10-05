using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBossEntry : MonoBehaviour
{
    [SerializeField] GameObject m_woodwall;
    [SerializeField] GameObject m_bossentey;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_woodwall.SetActive(true);
        m_bossentey.SetActive(true);
        Destroy(this.gameObject);
    }
}
