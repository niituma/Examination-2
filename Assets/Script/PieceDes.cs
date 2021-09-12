using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDes : MonoBehaviour
{
    MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 0);
        StartCoroutine("Transparent");
    }

    IEnumerator Transparent()
    {
        for (int i = 0; i < 255; i++)
        {
            mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(this.gameObject);
    }
}
