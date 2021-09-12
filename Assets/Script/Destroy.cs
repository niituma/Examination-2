using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private Explodable _explodable;
    void Des()
    {
        _explodable = GetComponent<Explodable>();
        int crash = Random.Range(1, 4);
        Debug.Log(crash);

        if (crash == 3)
        {
            ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
            _explodable.explode();
            if (ef != null)
            {
                ef.doExplosion(transform.position);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
