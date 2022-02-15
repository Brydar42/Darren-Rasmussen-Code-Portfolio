using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class crystalDragon : MonoBehaviour {
    public BoxCollider2D GombaBounds;
    public BoxCollider2D M_visionbounds;
    public GameObject m_target;
    SpriteRenderer M_Renderer;
    Animator m_Animator;
    float GOMBAMOVESPEED = 5f;
    float GOMBASEAKSPEED = 8f;
    float meleeDamage = 8f;
    public float totalHealth = 30f, currentHealth = 30f;
    public Image healthBar;
    public enum cystalDragonState
    {
        Idle,
        wandering,
        seeking,
        evading,
        attacking
    }
    public cystalDragonState m_gombastate = cystalDragonState.wandering;
    bool m_movingRight = false;
    // Use this for initialization
    void Start()
    {
        M_Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_gombastate)
        {
            case cystalDragonState.wandering:
                wanderGomba();
                break;
            case cystalDragonState.seeking:
                seekGomba();
                break;
            case cystalDragonState.evading:
                break;
        }
        currentHealth = Mathf.Clamp(currentHealth, 0, totalHealth);
        healthBar.fillAmount = currentHealth / totalHealth;
        if (currentHealth <= 0)
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
        if (collider.gameObject.layer == 11)
        {
            m_gombastate = cystalDragonState.seeking;
            m_target = collider.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            m_gombastate = cystalDragonState.wandering;
            m_target = null;
        }
    }
    void seekGomba()
    {
        Vector3 dir = m_target.transform.position - transform.position;
        dir.Normalize();
        transform.position += new Vector3(dir.x * GOMBASEAKSPEED * Time.deltaTime, 0, 0);
        if (dir.x > 0)
        {
            M_Renderer.flipX = false;
        }
        else if (dir.x < 0)
        {
            M_Renderer.flipX = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            collision.gameObject.GetComponent<PlayerScript>().currentHealth -= meleeDamage;
        }
    }
}