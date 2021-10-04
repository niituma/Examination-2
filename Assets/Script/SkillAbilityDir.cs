using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAbilityDir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = GameObject.Find("Player");
        if (Player)
        {
            if (Player.transform.localScale.x > 0)
            {
                this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            }
            else
            {
                this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            }
        }
    }
}
