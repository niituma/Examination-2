using UnityEngine;

public class FadeOutIn : MonoBehaviour
{
    [SerializeField] GameObject Panel = default;
    [SerializeField] AudioClip Asioto;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(Asioto,transform.position);
            Panel.SetActive(true);
            Destroy(this.gameObject);
        }
    }
    void FadeIn()
    {
        this.gameObject.SetActive(false);
    }
}
