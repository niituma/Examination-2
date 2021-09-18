using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    [SerializeField] float m_poisondamage = 5f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
        Debug.Log("poison");
        FindObjectOfType<PlayerHP>().HitLife(m_poisondamage);
        }
    }
}
