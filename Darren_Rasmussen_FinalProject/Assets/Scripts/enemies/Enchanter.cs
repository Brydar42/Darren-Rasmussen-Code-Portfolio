using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class Enchanter : MonoBehaviour {
    public float totalHealth = 10f, currentHealth = 10f;
    public Image healthBar;
    float meleeDamage = 3f;
    SpriteRenderer M_Renderer;
    public GameObject m_target;
    public GameObject MagicArrow;
    List<GameObject> MagicArrowList = new List<GameObject>();
    //A minimum of 3 second must have passed before shootng arrow to deal wth arrow spam 
    float reloadtime = 3f;

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
            GameObject addedMagicArrow = (GameObject)Instantiate(MagicArrow, transform.position, lookRot);
            addedMagicArrow.GetComponent<MagicArrow>().m_target = collider.gameObject.transform.position;
            if (dir.x < 0)
            {
                addedMagicArrow.GetComponent<SpriteRenderer>().flipY = true;
            }
            MagicArrowList.Add(addedMagicArrow);
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
                GameObject addedMagicArrow = (GameObject)Instantiate(MagicArrow, transform.position, lookRot);
                addedMagicArrow.GetComponent<MagicArrow>().m_target = collider.gameObject.transform.position;
                if (dir.x < 0)
                {
                    addedMagicArrow.GetComponent<SpriteRenderer>().flipY = true;
                }
                MagicArrowList.Add(addedMagicArrow);
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
