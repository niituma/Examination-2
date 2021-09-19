using UnityEngine;

public class SoldierController : MonoBehaviour
{
    [SerializeField] float m_attacktime;
    Animator m_anim = default;
    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_attacktime += Time.deltaTime;
        Attacktrue();
    }
    void Attacktrue()
    {
        if (m_attacktime >= 3f)
        {
            m_anim.SetBool("Attack", true);
        }
    }
    void Attackfalse()
    {
        m_anim.SetBool("Attack", false);
        m_attacktime = 0;
    }
}
