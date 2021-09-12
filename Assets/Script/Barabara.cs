using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barabara : MonoBehaviour
{
        private Explodable _explodable;
    void Explodable()
    {
        _explodable = GetComponent<Explodable>();
        _explodable.explode();
        ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
        if (ef != null)
        {
            ef.doExplosion(transform.position);
        }

    }


}
