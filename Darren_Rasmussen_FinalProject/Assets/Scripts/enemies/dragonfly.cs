using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class dragonfly : MonoBehaviour {
    public float totalHealth = 5f, currentHealth = 5f;
    public Image healthBar;
    float meleeDamage = 4f;
    float DragonFlyMoveSpeed = 7f;
    SpriteRenderer M_Renderer;
    public GameObject m_target;
    // Use this for initialization
    void Start () {
        M_Renderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (m_target != null)
        {
            Vector3 dir = m_target.transform.position - transform.position;
            dir.Normalize();
            transform.position += new Vector3(dir.x * DragonFlyMoveSpeed * Time.deltaTime, dir.y * DragonFlyMoveSpeed * Time.deltaTime, 0);
            if (dir.x > 0)
            {
                M_Renderer.flipX = false;
            }
            else if (dir.x < 0)
            {
                M_Renderer.flipX = true;
            }
        }
        currentHealth = Mathf.Clamp(currentHealth, 0, totalHealth);
        healthBar.fillAmount = currentHealth / totalHealth;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            m_target = collider.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            m_target = null;
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
