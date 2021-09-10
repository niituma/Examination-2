using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PbulletMove : MonoBehaviour
{
    /// <summary>弾が飛ぶ速さ</summary>
    [SerializeField] float m_speed = 3f;
    /// <summary>弾の生存期間（秒）</summary>
    [SerializeField] float m_lifeTime = 5f;
    [SerializeField] float m_amplitube = 1.5f;
    [SerializeField] float m_SpeedY = 3f;
    float m_timer;
    GameObject Plant = default;
    GameObject Player = default;
    Vector2 m_initialpostion;
    Rigidbody2D m_rb = default;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_initialpostion = this.transform.position;
        Destroy(this.gameObject, m_lifeTime);
        Player = GameObject.Find("Player");
        Plant = GameObject.Find("Plant");
        if (Plant?.transform.position.x > Player?.transform.position.x)
        {
            m_speed *= -1;
        }
        if (Plant?.transform.position.x < Player?.transform.position.x)
        {
            m_speed *= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        m_rb.velocity = new Vector2(m_speed, Mathf.Sin(m_timer * m_SpeedY) * m_amplitube);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
