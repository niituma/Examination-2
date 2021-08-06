using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private string AttackTag = "Air";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == AttackTag)
        {
            Debug.Log("攻撃を受けた");
        }
    }
}
