using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//simple code to move player,
public class PlayerMovemnt : MonoBehaviour {
    public int StoredPlayerNumber;
    public Camera playercamera;
    //public Camera firstcamera;
    public int PlayerNumber;
    public int money=300;
    public bool ready=false;
    Text moneyValue;
    GameObject UnitSelected;
    //public bool AvatarCamera;
    // Use this for initialization
    void Start () {
        //moneyValue= GameObject.Find("MoneyValue").GetComponent<Text>();
        playercamera = this.GetComponentInChildren<Camera>();
        PlayerNumber = StoredPlayerNumber;
    }
	
	// Update is called once per frame
	void Update () {
        //moneyValue.text = money.ToString();
        
        //move the player code
        /*if(AvatarCamera)
        {
            firstcamera.gameObject.SetActive(false);
            //playercamera = playercamera;
        }
        else
        {
            firstcamera.gameObject.SetActive(true);
            playercamera = firstcamera;
        }*/
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical") ;
        float rotate= Input.GetAxis("HorizontalRotation")*Time.deltaTime;

        gameObject.transform.rotation = new Quaternion( gameObject.transform.rotation.x, gameObject.transform.rotation.y + rotate, gameObject.transform.rotation.z, gameObject.transform.rotation.w);

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        transform.position += movement;
        //left mouse button
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = playercamera.ScreenPointToRay(Input.mousePosition);

            string TargetLayer="";

            RaycastHit hit;

            //do a raycast
            Physics.Raycast(ray, out hit, 100.0f);

            switch(PlayerNumber)
                {
                case 1:
                    TargetLayer = "Player1units";
                    break;
                case 2:
                    TargetLayer = "Player2units";
                    break;
            }

            //is it players unit
            if (hit.collider.gameObject.tag == TargetLayer)
            {
                CommandMovement UnitSelector = hit.collider.gameObject.GetComponent<CommandMovement>();
                UnitSelector.isSelected = true;
                UnitSelected = hit.collider.gameObject;
            }
            else 
            {
                if (UnitSelected != null)
                {
                    CommandMovement UnitSelector = UnitSelected.GetComponent<CommandMovement>();
                    UnitSelector.isSelected = false;
                    UnitSelected = null;
                }
            }
        }
        if (Input.GetMouseButton(1))
        {
            if (UnitSelected != null)
            {
                string TargetLayer = "";
                string OtherLayer = "";
                switch (PlayerNumber)
                {
                    case 1:
                        TargetLayer = "Player1units";
                        OtherLayer = "Player2units";
                        break;
                    case 2:
                        TargetLayer = "Player2units";
                        OtherLayer = "Player1units";
                        break;
                }
                Ray ray = playercamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //does the ray hit?
                if (Physics.Raycast(ray, out hit))
                {
                    //if (hit.collider.gameObject.tag == TargetLayer)
                    //{
                    //GameObject Unit = hit.collider.gameObject;
                    UnitSelected.GetComponent<CommandMovement>().aiStateChanger.currentstate = BasicAI.AiStates.moving;
                    //Step A move to location
                    Vector3 destination = new Vector3(hit.point.x, 1, hit.point.z);
                    UnitSelected.GetComponent<CommandMovement>().CmdScrPlayerSetDestination(destination);
                    //}
                }
            }

        }
    }
    
}
