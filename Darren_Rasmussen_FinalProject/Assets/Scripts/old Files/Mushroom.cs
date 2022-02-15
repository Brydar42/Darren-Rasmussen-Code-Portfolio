using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(5f, -5f);
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        /*  //player layer
          if (collision.gameObject.layer == 11)
          {
              collision.gameObject.GetComponent<PlayerScript>().M_collectcount++;
              Destroy(gameObject);
              //collision.gameObject.GetComponent<PlayerScript>().playerEat();
              collision.gameObject.GetComponent<PlayerScript>().currentHealth += 2;
          }*/

    }
}
