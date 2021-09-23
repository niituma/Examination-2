using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WbulletMove : MonoBehaviour
{
    /// <summary>弾の生存期間（秒）</summary>
    [SerializeField] float m_lifeTime = 5f;
    [SerializeField] GameObject WBulletHitEff = default;
    [SerializeField] AudioClip Hit;
    GameObject Player;
    public float Speed;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        Destroy(this.gameObject, m_lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player)
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(Player.transform.position.x, Player.transform.position.y + 3), Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(WBulletHitEff, this.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(Hit, transform.position);
            Destroy(this.gameObject);
        }
    }
}
