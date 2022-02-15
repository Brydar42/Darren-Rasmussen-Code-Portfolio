using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GombaAI : MonoBehaviour {
    public BoxCollider2D GombaBounds;
    public BoxCollider2D M_visionbounds;
    public GameObject m_target;
    SpriteRenderer M_Renderer;
    float GOMBAMOVESPEED = 4f;
    float GOMBASEAKSPEED = 8f;
    public float totalHealth = 20f, currentHealth = 20f;
    public Image healthBar;
    public enum GombaAItypes
    {
        Idle,
        wandering,
        seeking,
        evading,
        attacking
    }
    public GombaAItypes m_gombastate=GombaAItypes.wandering;
    bool m_movingRight=false;
    // Use this for initialization
    void Start () {
        M_Renderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
	    switch (m_gombastate)
        {
            case GombaAItypes.wandering:
                wanderGomba();
                break;
            case GombaAItypes.seeking:
                seekGomba();
                break;
            case GombaAItypes.evading:
                break;
        }
        currentHealth = Mathf.Clamp(currentHealth, 0, totalHealth);
        healthBar.fillAmount = currentHealth / totalHealth;
        if (currentHealth<=0)
        {
            gameObject.SetActive(false);
        }
    }
    void wanderGomba()
    {
        Vector3 pos = transform.position;
        if (m_movingRight)
        {
            if (pos.x < GombaBounds.transform.position.x + GombaBounds.size.x / 2f)
                transform.position = new Vector3(pos.x + GOMBAMOVESPEED * Time.deltaTime, pos.y, pos.z);
            else
                m_movingRight = false;
        }
        else
        {
            if (pos.x > GombaBounds.transform.position.x + GombaBounds.size.x / 2f)
                transform.position = new Vector3(pos.x + GOMBAMOVESPEED * Time.deltaTime, pos.y, pos.z);
            else
                m_movingRight = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer==11)
        {
            m_gombastate = GombaAItypes.seeking;
            GetComponent<Animator>().SetBool("IsSeaking", true);
            m_target = collider.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            m_gombastate = GombaAItypes.wandering;
            GetComponent<Animator>().SetBool("IsSeaking", false);
            m_target = null;
        }
    }
    void seekGomba()
    {
        Vector3 dir = m_target.transform.position - transform.position;
        dir.Normalize();
        transform.position += new Vector3(dir.x *GOMBASEAKSPEED*Time.deltaTime,0,0);
        if (dir.x < 0)
        {
            M_Renderer.flipX = false;
        }
        else if (dir.x>0)
        {
            M_Renderer.flipX = true;
        }
    }
}
