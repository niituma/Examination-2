using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScean : MonoBehaviour
{
    [SerializeField] int m_count = 0;
    private void Start()
    {
        FindObjectOfType<RestartManager>().SceanCount(m_count);
        Destroy(this.gameObject);
    }
}
