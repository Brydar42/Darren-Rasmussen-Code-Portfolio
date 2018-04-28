using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetTextElement : MonoBehaviour {
    public Text ElementChanged;
	// Use this for initialization
	void Start () {
        ElementChanged = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
