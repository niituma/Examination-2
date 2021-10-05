using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosspauseManager : MonoBehaviour
{
    bool isbosspause = default;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
    }
    public void PauseResume()
    {
        var bosspause = GameObject.Find("BossPauseManager");
        if (bosspause != null)
        {
            if (!isbosspause)
            {
                isbosspause = true;
                FindObjectOfType<Pauser>().Pause();
            }
            else
            {
                isbosspause = false;
                FindObjectOfType<Pauser>().Resume();
            }
        }
    }
}
