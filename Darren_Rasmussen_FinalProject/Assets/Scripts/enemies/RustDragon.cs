using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class RustDragon : MonoBehaviour
{
    public float totalHealth = 40f, currentHealth = 40f;
    public Image healthBar;
    float meleeDamage = 5f;
    float DragonMoveSpeed = 5f;
    SpriteRenderer M_Renderer;
    public GameObject m_target;
    public GameObject AcidBall;
    List<GameObject> AcidBallList = new List<GameObject>();
    //A minimum of 3 second must have passed before shootng arrow to deal wth arrow spam 
    float reloadtime = 2f;

    //The next Time.time value where arrow can be prodduced.
    float nextshottime = 0f;
    // Use this for initialization
    void Start()
    {
        M_Renderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (m_target != null)
        {
            Vector3 dir = m_target.transform.position - transform.position;
            dir.Normalize();
            transform.position += new Vector3(dir.x * DragonMoveSpeed * Time.deltaTime, dir.y * DragonMoveSpeed * Time.deltaTime, 0);
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
            Vector3 dir = transform.position - collider.gameObject.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x);
            Quaternion lookRot = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
            GameObject addedAcidBall = (GameObject)Instantiate(AcidBall, transform.position, lookRot);
            addedAcidBall.GetComponent<acidBreath>().m_target = collider.gameObject.transform.position;
            if (dir.x < 0)
            {
                addedAcidBall.GetComponent<SpriteRenderer>().flipY = true;
            }
            AcidBallList.Add(addedAcidBall);
            m_target = collider.gameObject;
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            float currentTime = Time.time;
            if (currentTime > nextshottime)
            {
                Vector3 dir = transform.position - collider.gameObject.transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x);

                Quaternion lookRot = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
                GameObject addedAcidBall = (GameObject)Instantiate(AcidBall, transform.position, lookRot);
                addedAcidBall.GetComponent<acidBreath>().m_target = collider.gameObject.transform.position;
                if (dir.x < 0)
                {
                    addedAcidBall.GetComponent<SpriteRenderer>().flipY = true;
                }
                AcidBallList.Add(addedAcidBall);
                nextshottime = currentTime + reloadtime;
            }
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
