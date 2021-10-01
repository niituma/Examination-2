using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageWall : MonoBehaviour
{
    [SerializeField] GameObject Enemy = default;

    // Update is called once per frame
    void Update()
    {
        int m_ChildCount = Enemy.transform.childCount;
        if (m_ChildCount == 0)
        {
            this.GetComponent<Animator>().enabled = true;
        }
    }
    void Walldes()
    {
        Destroy(this.gameObject);
    }
}
