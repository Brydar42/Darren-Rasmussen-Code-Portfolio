using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Sharpshooter : MonoBehaviour {
    public float totalHealth = 10f, currentHealth = 10f;
    public Image healthBar;
    float meleeDamage = 1f;
    public GameObject Arrow;
    List<GameObject> ArrowList = new List<GameObject>();
    //A minimum of 3 second must have passed before shootng arrow to deal wth arrow spam 
    float reloadtime = 3f;

    //The next Time.time value where arrow can be prodduced.
    float nextshottime=0f;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        currentHealth = Mathf.Clamp(currentHealth, 0, totalHealth);
        healthBar.fillAmount = currentHealth / totalHealth;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        GetComponent<Animator>().SetBool("Cansee", true);
        if (collider.gameObject.layer == 11)
        {
            if (collider.gameObject.transform.position.y > transform.position.y)
            {
                GetComponent<Animator>().SetBool("enemyHigh", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("enemyHigh", false);
            }
            Vector3 dir = transform.position - collider.gameObject.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x);
            Quaternion lookRot = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
            GameObject addedArrow = (GameObject)Instantiate(Arrow, transform.position, lookRot);
            addedArrow.GetComponent<GoldBill>().m_target = collider.gameObject.transform.position;
            if (dir.x < 0)
            {
                addedArrow.GetComponent<SpriteRenderer>().flipY = true;
            }
            ArrowList.Add(addedArrow);
        }
    }
    //removed due to mass of arrows readded with delay 2022 change
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            float currentTime = Time.time;
            if (currentTime>nextshottime)
            { 
                GetComponent<Animator>().SetBool("Cansee", true);
                if (collider.gameObject.transform.position.y > transform.position.y)
                {
                    GetComponent<Animator>().SetBool("enemyHigh", true);
                }
                else
                {
                    GetComponent<Animator>().SetBool("enemyHigh", false);
                }
                Vector3 dir = transform.position - collider.gameObject.transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x);
            
                Quaternion lookRot = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
                GameObject addedArrow = (GameObject)Instantiate(Arrow, transform.position, lookRot);
                addedArrow.GetComponent<GoldBill>().m_target = collider.gameObject.transform.position;
                if (dir.x < 0)
                {
                    addedArrow.GetComponent<SpriteRenderer>().flipY = true;
                }
                ArrowList.Add(addedArrow);
                nextshottime = currentTime + reloadtime;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        GetComponent<Animator>().SetBool("Cansee", false);
    }
        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            GetComponent<Animator>().SetBool("melee", true);
            collision.gameObject.GetComponent<PlayerScript>().currentHealth -= meleeDamage;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            GetComponent<Animator>().SetBool("melee", false);
        }
    }
}
    
