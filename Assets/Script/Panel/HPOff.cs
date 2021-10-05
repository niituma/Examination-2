using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPOff : MonoBehaviour
{
    GameObject HP = default;
    // Start is called before the first frame update
    void Start()
    {
        HP = GameObject.Find("DDOL");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP)
            Destroy(HP.gameObject);
        //HP.SetActive(false);
    }
}
