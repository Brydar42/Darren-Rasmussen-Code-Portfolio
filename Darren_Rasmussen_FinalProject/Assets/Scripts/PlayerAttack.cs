using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    public SphereCollider RightHand;
    public SphereCollider LeftHand;
    public GameObject Rifle;
	// Use this for initialization
	void Start () {
        RightHand.enabled = false;
        LeftHand.enabled = false;
	}
	public void setRightHand(int active)
    {
        RightHand.enabled = (active == 0) ? false : true;
    }
    public void setLeftHand(int active)
    {
        LeftHand.enabled = (active == 0) ? false : true;
    }
    public void showRifle(int active)
    {
        Rifle.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
