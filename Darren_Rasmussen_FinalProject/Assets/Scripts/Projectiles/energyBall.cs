using UnityEngine;
using System.Collections;

public class energyBall : MonoBehaviour {

    const float DAMAGE = 7f;
    const float Speed = 3f;
    public Vector2 m_target;
    public Rigidbody2D m_ridgedBody;
    // Use this for initialization
    void Start()
    {
        Vector2 dir = m_target - new Vector2(transform.position.x, transform.position.y);
        m_ridgedBody.AddForce(dir, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cambos = Camera.main.transform.position;
        if (transform.position.x < cambos.x + PlayerScript.MIN_X_BOUNDS || transform.position.x > cambos.x + PlayerScript.MAX_X_BOUNDS || transform.position.y > Camera.main.orthographicSize || transform.position.y < -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11)
        {
            Destroy(gameObject);
            collider.gameObject.GetComponent<PlayerScript>().currentHealth -= DAMAGE;
        }
        if (collider.gameObject.layer == 15)
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
    }
}
