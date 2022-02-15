using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerInputScript : MonoBehaviour {
    SpriteRenderer m_Renderer;
    public Animator m_Animator;
    Rigidbody2D m_RigidBody;
    public PlayerScript m_playerscript;
    public GameObject m_BulletBill;
    public GameObject Mushroom;
    const float PLAYER_NORMAL_SPEED = 5f;
    const float PLAYER_EXTRA_SPEED = 5f;
    const float GROUND_HEIGHT = -3.4f;
    public float MIN_JUMP_FORCE = 70f;
    //bool m_MovingRight = true;
    List<GameObject> m_BulletBillList = new List<GameObject>();
    const float BULLETBILL_SPEED = 8f;
    
    
    // Use this for initialization
    void Start() {
        m_Animator = GetComponent<Animator>();
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<SpriteRenderer>();
        
    }
    void FixedUpdate()
    { 
       /* if (m_Animator.GetBool("IsDucking"))
        {
            m_RigidBody.velocity = new Vector3(0, m_RigidBody.velocity.y, 0);
        }*/
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (transform.position.x - m_Renderer.bounds.extents.x < PlayerScript.MIN_X_BOUNDS)
            {
                m_RigidBody.velocity = new Vector3(0, m_RigidBody.velocity.y, 0);
            }
            else
            {
                m_RigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * PLAYER_NORMAL_SPEED - PLAYER_EXTRA_SPEED * Input.GetAxis("Acceleration"), m_RigidBody.velocity.y, 0);
            }
        }

        else if (Input.GetAxis("Horizontal") > 0)
        {
            m_RigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * PLAYER_NORMAL_SPEED + PLAYER_EXTRA_SPEED * Input.GetAxis("Acceleration"),
                m_RigidBody.velocity.y, 0);
        }
        else
        {
            m_RigidBody.velocity = new Vector3(0f, m_RigidBody.velocity.y, 0f);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 spawnPos = gameObject.transform.position + new Vector3(1f, 2f, 0);

            GameObject bulletBill = (GameObject)Instantiate(m_BulletBill, spawnPos, Quaternion.identity);
            m_BulletBillList.Add(bulletBill);
            SpriteRenderer renderer = bulletBill.GetComponent<SpriteRenderer>();
            Rigidbody2D rigidBody = bulletBill.GetComponent<Rigidbody2D>();

            if (m_Renderer.flipX)
            {
                rigidBody.AddForce(Vector2.left * BULLETBILL_SPEED, ForceMode2D.Impulse);
                renderer.flipX = true;

            }
            else
            {
                rigidBody.AddForce(Vector2.right * BULLETBILL_SPEED, ForceMode2D.Impulse);
                renderer.flipX = false;
            }

        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==9)
        m_Animator.SetBool("IsJumping", false);
        if (collision.gameObject.layer == 10)
        {
            BoxCollider2D m_blockCollider = collision.gameObject.GetComponent<BoxCollider2D>();
            if ((transform.position.y + m_Renderer.bounds.extents.y) < (collision.gameObject.transform.position.y - m_blockCollider.size.y))
            {
                Instantiate(Mushroom, collision.gameObject.transform.position + new Vector3(0, 2f, 0), Quaternion.identity);
                m_playerscript.Playercollect();
            }
            if (transform.position.y > collision.gameObject.transform.position.y + m_blockCollider.size.y)
            {
                m_Animator.SetBool("IsJumping", false);
            }
        }
        if (collision.gameObject.layer==13)
        {
            CircleCollider2D Collider = collision.gameObject.GetComponent<CircleCollider2D>();
            if (transform.position.y > collision.gameObject.transform.position.y + Collider.radius)
            {
                m_Animator.SetBool("IsJumping", false);
            }
        }
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            m_Animator.SetBool("IsJumping", false);
        }
        if (collision.gameObject.layer == 10)
        {
            m_RigidBody.AddForce(Vector2.down*100);
        }
    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            m_Renderer.flipX = false;
            m_Animator.SetBool("IsWalking", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            m_Renderer.flipX = true;
            m_Animator.SetBool("IsWalking", true);
        }
        else
            m_Animator.SetBool("IsWalking", false);
        if (Input.GetKeyDown(KeyCode.W) && !m_Animator.GetBool("IsJumping"))
        {
            m_Animator.SetBool("IsJumping", true);
            m_RigidBody.AddForce(new Vector2(0, MIN_JUMP_FORCE), ForceMode2D.Impulse);
            m_RigidBody.gravityScale = 0.5f;
        }
        if (Input.GetKey(KeyCode.Space))
            m_Animator.SetBool("IsRunning", true);
        else
            m_Animator.SetBool("IsRunning", false);
        /*//While holding the 'S' key
        if (Input.GetKey(KeyCode.S))
        {
            m_Animator.SetBool("IsDucking", true);
        }
        //while not holding 'S'
        else
        {
            m_Animator.SetBool("IsDucking", false);
        }*/
    }


}
