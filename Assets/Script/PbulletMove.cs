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
    [SerializeField] float m_SpeedX = 3f;
    Vector2 m_initialpostion;
    float m_timer;
    private GameObject Gunman;
    // Start is called before the first frame update
    void Start()
    {
        m_initialpostion = this.transform.position;
        Destroy(this.gameObject, m_lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        float posY = Mathf.Sin(m_timer * m_SpeedY) * m_amplitube;
        float posX = m_timer * m_SpeedX;
        Vector2 pos = m_initialpostion + new Vector2(posX,posY);
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
