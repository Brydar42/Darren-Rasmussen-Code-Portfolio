using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class KopaScript : MonoBehaviour {
    public float totalHealth = 5f, currentHealth = 5f;
    public Image healthBar;
    public GameObject GoldBill;
    List<GameObject> GoldenBillList= new List<GameObject>();
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
        if (collider.gameObject.layer == 11)
        {
            Vector3 dir = transform.position - collider.gameObject.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x);
            /*
            
                lookRot = Quaternion.LookRotation(dir, Vector3.up);
            lookRot.x = lookRot.y = 0;
            */
            Quaternion lookRot = Quaternion.Euler(0,0,angle*Mathf.Rad2Deg);
            GameObject Goldenbill =(GameObject)Instantiate(GoldBill, transform.position,lookRot);
            Goldenbill.GetComponent<GoldBill>().m_target = collider.gameObject.transform.position;
            if (dir.x < 0)
            {
                Goldenbill.GetComponent<SpriteRenderer>().flipY = true;
            }
            GoldenBillList.Add(Goldenbill);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            collision.gameObject.GetComponent<PlayerScript>().currentHealth -= 2f;
        }
        
    }
}
