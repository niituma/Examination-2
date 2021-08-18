using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbitmove : MonoBehaviour
{
    [SerializeField] float m_Speed = 3f;
    [SerializeField] GameObject Player = default;
    [SerializeField] GameObject REnemy = default;
    Rigidbody2D m_rb = default;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "camera")
        {
        REnemy.transform.position = Vector2.MoveTowards(this.transform.position,new Vector2(Player.transform.position.x,transform.position.y),m_Speed * Time.deltaTime);
        }
    }
}
