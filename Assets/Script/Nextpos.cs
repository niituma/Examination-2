using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextpos : MonoBehaviour
{
    GameObject Player = default;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("DDOL");
        Player.transform.position = new Vector3(-6, 2, -46);
    }
}
