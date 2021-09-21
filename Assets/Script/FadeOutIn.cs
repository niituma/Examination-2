using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutIn : MonoBehaviour
{
    [SerializeField] GameObject Panel = default;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        Panel.SetActive(true);
    }
    void FadeIn()
    {
        this.gameObject.SetActive(false);
    }
}
