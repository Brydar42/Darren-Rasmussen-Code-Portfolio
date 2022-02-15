using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {
    public GameObject PlayerLance;
    public GameObject EnemyLance;
    public enemyAI enemyAI;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider collider)
    {
        //enemy lance pickup
        if (collider.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            EnemyLance.SetActive(true);
            enemyAI.SwitchState(enemyAI.AISTATE.Wander);
        }
        //player lance
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerLance.SetActive(true);
        }
    }
}
