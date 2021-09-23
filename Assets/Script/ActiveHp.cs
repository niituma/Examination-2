using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveHp : MonoBehaviour
{
    GameObject HP;
    float m_heel = 155f;
    // Start is called before the first frame update
    void Start()
    {
        HP = GameObject.Find("SliderHP");
        HP.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerHP>().AddLife(m_heel);
            Destroy(this.gameObject);
        }
    }
}
