using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Explodable _explodable;
    private void Start()
    {
        _explodable = GetComponent<Explodable>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attackpoint")
        {
            _explodable.explode();
            ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
            if (ef != null)
            {
                ef.doExplosion(transform.position);
            }
            Debug.Log("a");
        }
    }


}
