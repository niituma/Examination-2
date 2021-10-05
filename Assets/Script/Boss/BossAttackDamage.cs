using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackDamage : MonoBehaviour
{
    [SerializeField] float m_damage = 20f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerHP>().HitLife(m_damage);
        }
    }
}
