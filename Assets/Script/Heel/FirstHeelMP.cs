using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstHeelMP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float HeelMP = 999;
        FindObjectOfType<PlayerMP>().FirstMP(HeelMP);
    }
}
