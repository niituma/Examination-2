using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    [SerializeField] GameObject Effect = default;
    [SerializeField] AudioClip AttackHit;
    [SerializeField] AudioClip AttackHit2;
    [SerializeField] AudioClip AttackHit3;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attackpoint" || other.tag == "Attackpoint2" || other.tag == "Attackpoint3")
        {
            Vector3 hitPos = other.bounds.ClosestPoint(this.transform.position);
            Instantiate(Effect, hitPos, Quaternion.identity);
            //エフェクト生成処理
        }
        if(other.tag == "Attackpoint")
        {
            AudioSource.PlayClipAtPoint(AttackHit, transform.position);
        }
        else if (other.tag == "Attackpoint2")
        {
            AudioSource.PlayClipAtPoint(AttackHit2, transform.position);
        }
        else if (other.tag == "Attackpoint3")
        {
            AudioSource.PlayClipAtPoint(AttackHit3, transform.position);
        }
    }
}



