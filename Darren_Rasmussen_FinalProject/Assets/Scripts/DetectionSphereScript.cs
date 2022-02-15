using UnityEngine;
using System.Collections;

public class DetectionSphereScript : MonoBehaviour {
    public enemyAI enemyAI;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            enemyAI.SwitchState(enemyAI.AISTATE.Seek);
            Debug.Log("SEEKING");
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            enemyAI.SwitchState(enemyAI.AISTATE.Wander);
            Debug.Log("WANDERING");
        }
    }
}
