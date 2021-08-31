using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    [SerializeField] float m_Speed = 4f;
    [SerializeField] float m_RSpeed = 4f;
    [SerializeField] public GameObject Player = default;
    [SerializeField] public float Stopdis = 3f;
    public float dis;
    public bool isstop = true;


    public void Update()
    {
        Vector2 PoseA = Player.transform.position;
        Vector2 PoseB = this.transform.position;
        dis = Vector2.Distance(PoseA, PoseB);
        if (dis <= Stopdis && isstop == true)
        {
            isstop = false;
            m_Speed = 0f;
        }
        else if (dis > Stopdis && isstop == false)
        {
            isstop = true;
            m_Speed = m_RSpeed;
        }
        EFlipx();

    }
    // Update is called once per frame
    public void OnTriggerStay2D(Collider2D collision)
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
        m_Speed = m_RSpeed;
    }
    void EFlipx()
    {
        if (this.transform.position.x > Player.transform.position.x)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        if (this.transform.position.x < Player.transform.position.x)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
}
