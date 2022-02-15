using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ObjectForceUp : MonoBehaviour
{
    Rigidbody rigidBody;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        PlayerMovement.OnMouseClick += ForceUp;
    }

    void OnDestroy()
    {
        PlayerMovement.OnMouseClick -= ForceUp;
    }

    void ForceUp()
    {
        rigidBody.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }


	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
