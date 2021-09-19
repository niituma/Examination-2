using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybasemove : MonoBehaviour
{
    [SerializeField] float m_Speed = 4f;
    [SerializeField] float m_RSpeed = 4f;
    [SerializeField] GameObject Player = default;
    [SerializeField] public float Stopdis = 3f;
    public float dis;
    public bool isstop = true;
    public virtual void Activate()
    {
        Debug.Log("オーバーライドしてください。");
    }

    public void Update()
    {
        if (Player)
        {
            Vector2 PoseA = (Vector2)(Player?.transform.position);
            Vector3 PoseB = this.transform.position;
            dis = Vector2.Distance(PoseA, PoseB);
        }
        if (dis <= Stopdis && isstop == true)
        {
            m_Speed = 0f;
            isstop = false;
        }
        else if (dis > Stopdis && isstop == false)
        {
            m_Speed = m_RSpeed;
            isstop = true;
        }
        //Activate();
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
    void Tracking()
    {
        if(GetComponent<RabbitController>())
        Destroy(GetComponent<RabbitController>());
        if(GetComponent<SkeletonController>())
        Destroy(GetComponent<SkeletonController>());
    }
    public void EFlipx()
    {
        if (Player)
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
}
