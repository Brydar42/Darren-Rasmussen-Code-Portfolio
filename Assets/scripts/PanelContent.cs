using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
//a middle man script that then calls the srcipt in create units
public class PanelContent : NetworkBehaviour{
    public CreateUnit toIntancate;
    public int whichPlayer;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i=0;i>toIntancate.Players.Count;i++)
        {
            if(i!=whichPlayer)
                gameObject.SetActive(false);
        }
        //if everyoneis are ready no need for panel
        if (toIntancate.readyToStart)
            gameObject.SetActive(false);
    }
   
}
