using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDestroy : MonoBehaviour
{
    private Explodable _explodable;
    void Des()
    {
        _explodable = GetComponent<Explodable>();
        int crash = 3;// Random.Range(1, 4);
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
            Destroy(this.gameObject,0.4f);
        }
    }
    void DestroyMob()
    {
        Destroy(this.gameObject);
    }
}
