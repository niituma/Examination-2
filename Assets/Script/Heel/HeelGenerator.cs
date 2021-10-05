using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelGenerator : MonoBehaviour
{
    [SerializeField] float m_timer;
    [SerializeField] float m_limittime = 15f;
    [SerializeField] GameObject m_heelball = default;
    GameObject m_obj;

    // Update is called once per frame
    void Update()
    {
        int m_ChildCount = this.transform.childCount;

        m_timer += Time.deltaTime;

        if(m_timer >= m_limittime && m_ChildCount == 0)
        {
            m_obj = Instantiate(m_heelball, this.transform.position, Quaternion.identity);
            m_obj.transform.parent = this.transform;
            m_timer = 0;
        }
        else if(m_ChildCount > 0)
        {
            m_timer = 0;
        }

    }
}
