using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    [SerializeField] GameObject Panel = default;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Panel.SetActive(true);
    }
}
