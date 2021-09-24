using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    [SerializeField] float m_skilldamage = 15;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boss")
        {
            FindObjectOfType<BossHP>().HitLife(m_skilldamage);
        }
    }
}
