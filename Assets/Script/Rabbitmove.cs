using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbitmove : MonoBehaviour
{
    public float m_Speed = 4f;
    [SerializeField] GameObject Player = default;
    [SerializeField] float limittime = 2f; 
    float Stoptimer = 0;
    Rigidbody2D m_rb = default;
    float dis;
    public bool isstop = true;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 PoseA = Player.transform.position;
        Vector2 PoseB = this.transform.position;
        dis = Vector2.Distance(PoseA, PoseB);
        if (dis <= 3f && isstop == true)
        {
            isstop = false;
            m_Speed = 0f;
        }
        else if(dis > 3f && isstop == false)
        {
            isstop = true;
            m_Speed = 4f;
        }

        
    }
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "camera")
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(Player.transform.position.x, transform.position.y), m_Speed * Time.deltaTime);
        }
    }

    void Hitspeedstop()
    {
        m_Speed = 0f;
    }
    void Enemyremove()
    {
        m_Speed = 4f;
    }
}
