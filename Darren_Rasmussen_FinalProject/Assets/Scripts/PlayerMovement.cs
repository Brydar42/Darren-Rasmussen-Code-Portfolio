using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public delegate void MouseClick();
    public static event MouseClick OnMouseClick;

    Vector3 Velocity = Vector3.zero;
    public Camera playerCamera;
    public float speed = 10f;

    public float horizTurnSpeed = 3f;
    public float verticalTurnSpeed = 3f;

    public Rigidbody rigidBody;

    public float m_GroundCheckDistance = 2f;

    Vector3 m_GroundNormal;
    public bool m_IsGrounded;

    public float PunchForce = 100f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        if (pos.y < 2.029 || pos.y > 2.029)
        {
            pos.y = 2.029f;
        }
        Velocity = playerCamera.transform.forward * Input.GetAxis("Forward") * speed;
        Velocity += playerCamera.transform.right * Input.GetAxis("Horizontal") * speed;

        CheckGroundStatus();

        Velocity = Vector3.ProjectOnPlane(Velocity, m_GroundNormal);

        if (!m_IsGrounded)
            rigidBody.AddForce(Vector3.down * 10, ForceMode.Impulse);

        rigidBody.velocity = Velocity;
        ApplyPlayerRotation();
        ApplyCameraRotation();

    }



    void ApplyPlayerRotation()
    {
        gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * horizTurnSpeed, 0);
    }

    void ApplyCameraRotation()
    {
        playerCamera.transform.Rotate(-Input.GetAxis("Mouse Y") * verticalTurnSpeed, 0, 0);
    }

    void CheckGroundStatus()
    {
#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(transform.position + (Vector3.up * 0.01f),
            transform.position + (Vector3.down * 0.1f) +
            (Vector3.down * m_GroundCheckDistance),
            Color.red);
#endif

        RaycastHit hitInfo;

        bool isHit = Physics.Raycast(transform.position + (Vector3.up * 0.01f),
                                        Vector3.down, out hitInfo, m_GroundCheckDistance);

        if (isHit)
        {
            m_GroundNormal = hitInfo.normal;
            m_IsGrounded = true;
        }
        else
        {
            m_GroundNormal = Vector3.up;
            m_IsGrounded = false;
        }


    }


}