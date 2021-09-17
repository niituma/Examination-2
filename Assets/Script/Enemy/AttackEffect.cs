using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    [SerializeField] GameObject Effect = default;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Attackpoint")
        {
        Vector3 hitPos = other.bounds.ClosestPoint(this.transform.position);
        Instantiate(Effect, hitPos, Quaternion.identity);
        //エフェクト生成処理
        }
    }
}



