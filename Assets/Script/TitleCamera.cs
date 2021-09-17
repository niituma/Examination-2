using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    [SerializeField] float m_speed = 3f;
    float m_firstpos;

    private void Start()
    {
        m_firstpos = transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        x += m_speed * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        if(x >= 150)
        {
            x = m_firstpos;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}
