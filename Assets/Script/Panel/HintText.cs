using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintText : MonoBehaviour
{
    [SerializeField] GameObject Hint = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Hint.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Hint.SetActive(false);
    }
}
