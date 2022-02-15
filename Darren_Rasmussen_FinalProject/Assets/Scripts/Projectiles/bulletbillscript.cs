using UnityEngine;
using System.Collections;

public class bulletbillscript : MonoBehaviour {
    const float Bullet_damage = 3f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cambos = Camera.main.transform.position;
        if (transform.position.x < cambos.x + PlayerScript.MIN_X_BOUNDS || transform.position.x > cambos.x + PlayerScript.MAX_X_BOUNDS)
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        //enemy
        if (collider.gameObject.layer==8)
        {
            if (collider.GetType() == typeof(BoxCollider2D))
            {
                collider.gameObject.GetComponent<Sharpshooter>().currentHealth -= Bullet_damage;
                Destroy(gameObject);
            }
        }
       
        if(collider.gameObject.layer== 13)
        {
             if (collider.GetType() == typeof(CircleCollider2D))
            {
                collider.gameObject.GetComponent<crystalDragon>().currentHealth -= Bullet_damage;
                Destroy(gameObject);
            }
        }
        if (collider.gameObject.layer == 19)
        {
            if (collider.GetType() == typeof(BoxCollider2D))
            {
                collider.gameObject.GetComponent<dragonfly>().currentHealth -= Bullet_damage;
                Destroy(gameObject);
            }
        }

        if (collider.gameObject.layer == 18)
        {
            if (collider.GetType() == typeof(BoxCollider2D))
            {
                collider.gameObject.GetComponent<BlackDragon>().currentHealth -= Bullet_damage;
                Destroy(gameObject);
            }
        }
        if (collider.gameObject.layer == 12)
        {
            if (collider.GetType() == typeof(BoxCollider2D))
            {
                collider.gameObject.GetComponent<stormElemental>().currentHealth -= Bullet_damage;
                Destroy(gameObject);
            }
        }

        if (collider.gameObject.layer == 10)
        {
            if (collider.GetType() == typeof(BoxCollider2D))
            {
                collider.gameObject.GetComponent<Enchanter>().currentHealth -= Bullet_damage;
                Destroy(gameObject);
            }
        }
        if (collider.gameObject.layer == 16)
        {
            if (collider.GetType() == typeof(BoxCollider2D))
            {
                collider.gameObject.GetComponent<Zealot>().currentHealth -= Bullet_damage;
                Destroy(gameObject);
            }
        }

        if (collider.gameObject.layer == 17)
        {
            if (collider.GetType() == typeof(BoxCollider2D))
            {
                collider.gameObject.GetComponent<RustDragon>().currentHealth -= Bullet_damage;
                Destroy(gameObject);
            }
        }
    }
}
