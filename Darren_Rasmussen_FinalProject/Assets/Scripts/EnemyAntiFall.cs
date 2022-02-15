using UnityEngine;
using System.Collections;

public class EnemyAntiFall : MonoBehaviour {
    public Rigidbody enemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = gameObject.transform.position;
        if (pos.y != 0)
        {
            pos.y = 0;
        }
    }
}
