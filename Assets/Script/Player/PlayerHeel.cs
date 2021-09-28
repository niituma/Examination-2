using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeel : MonoBehaviour
{
    [SerializeField] float m_heelpoint = 10;
    [SerializeField] float m_SpeedY = 3f;
    [SerializeField] float m_amplitube = 1.5f;
    [SerializeField] AudioClip HeelAudio;
    float m_timer;
    Rigidbody2D m_rb = default;
    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        m_timer += Time.deltaTime;
        m_rb.velocity = new Vector2(0, Mathf.Sin(m_timer * m_SpeedY) * m_amplitube);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Heel");
            AudioSource.PlayClipAtPoint(HeelAudio, transform.position);
            FindObjectOfType<PlayerHP>().AddLife(m_heelpoint);
            Destroy(this.gameObject);
        }
    }
}
