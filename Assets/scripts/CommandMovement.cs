using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;
//this script is all about moving the units of both players
//todo:make ai using the sphere triger collider as an attack range
public class CommandMovement : NetworkBehaviour
{ 
    public NetworkTransform UnitPosition;
    public float UnitSpeed=5.0f;
    public bool isSelected;
    //public List<PlayerController> Players = new List<PlayerController>();
    //public Camera avatarcamra;
    NavMeshAgent character;
    public BasicAI aiStateChanger;
    public ParticleSystem selection1;
    public ParticleSystem selection2;
	// Use this for initialization
	void Start () {
        //loops to check for players and adding them
        /*for (int i = 0; i < ClientScene.localPlayers.Count; i++)
        {
            bool newPlayer = true;
            for (int j = 0; j < Players.Count; j++)
            {
                //is the player already there if not add it
                if (ClientScene.localPlayers[i] == Players[j])
                {
                    newPlayer = false;
                }
            }
            if (newPlayer)
            {
                Players.Add(ClientScene.localPlayers[i]);
            }
        }
        //is there a player if so it's player 1
        if (Players.Count > 0)
        { player1camera = Players[0].gameObject.GetComponentInChildren<Camera>(); }
        //is the second player in the game
        if (Players.Count > 1)
        { player2camera = Players[1].gameObject.GetComponentInChildren<Camera>(); }*/
        //get navmesh
        UnitPosition = gameObject.GetComponent<NetworkTransform>();
        character = gameObject.GetComponent<NavMeshAgent>();
        isSelected = false;
        aiStateChanger = gameObject.GetComponent<BasicAI>();
        if(aiStateChanger.unittype==BasicAI.AI_TYPES.spearman)
        character.speed = UnitSpeed;
        //not giving full movement so that archers can run forever from any infantry or hit move hit move
        if (aiStateChanger.unittype == BasicAI.AI_TYPES.archer)
            character.speed = UnitSpeed*0.75f;
        //make them double the speed
        if (aiStateChanger.unittype == BasicAI.AI_TYPES.calvery)
            character.speed = UnitSpeed*2;
    }
    //work to sync the movement
    [Command]
    public void CmdScrPlayerSetDestination(Vector3 argPosition)
    {//Step B, I do simple work, I not verifi a valid position in server, I only send to all clients
        RpcScrPlayerSetDestination(argPosition);
    }

    [ClientRpc]
    public void RpcScrPlayerSetDestination(Vector3 argPosition)
    {//Step C, only the clients move
            if(aiStateChanger.unittype==BasicAI.AI_TYPES.calvery)
                character.SetDestination(argPosition+new Vector3 (UnitSpeed*Time.deltaTime,0,UnitSpeed * Time.deltaTime));
            else
            character.SetDestination(argPosition);
    }

    // Update is called once per frame
    [ServerCallback]
    void Update () {
        if (character.pathStatus == NavMeshPathStatus.PathComplete)
        {
            aiStateChanger.currentstate = BasicAI.AiStates.idle;
        }
        //loops to check for players and adding them
        /*for (int i=0; i< ClientScene.localPlayers.Count; i++)
        {
            bool newPlayer=true;
            for(int j=0;j<Players.Count;j++)
            {
                //is the player already there if not add it
                if(ClientScene.localPlayers[i]==Players[j])
                {
                    newPlayer = false;
                }
            }
            if(newPlayer)
            {
                Players.Add(ClientScene.localPlayers[i]);
            }
        }
        //is there a player if so it's player 1
        if(Players.Count>0)
        { player1camera = Players[0].gameObject.GetComponentInChildren<Camera>(); }
        //is the second player in the game
        if (Players.Count > 1)
        { player2camera = Players[1].gameObject.GetComponentInChildren<Camera>(); }*/
        //selected
        if (isSelected)
        {
            //first off the particle effects
            //is it player1's unit
            if (gameObject.tag == "Player1units")
            {
                selection1.Play();
                selection2.Stop();
                //avatarcamra.gameObject.SetActive(true);
                //Players[0].gameObject.GetComponent<PlayerMovemnt>().playercamera=avatarcamra;
                //Players[0].gameObject.GetComponent<PlayerMovemnt>().AvatarCamera = true;


            }
            //is it player2's unit
            else if(gameObject.tag == "Player2units")
            {
                selection1.Play();
                selection2.Stop();
                //avatarcamra.gameObject.SetActive(true);
                //Players[1].gameObject.GetComponent<PlayerMovemnt>().playercamera = avatarcamra;
                //Players[1].gameObject.GetComponent<PlayerMovemnt>().AvatarCamera = true;
            }
            //right mouse button
           
        }
        //nothing selected stop any possable effercts
        else
        {
            selection1.Stop();
            selection2.Stop();
            /*//safty check so that only one player will be affected
                if (isSelected&& gameObject.tag == "Player1units")
                    Players[0].gameObject.GetComponent<PlayerMovemnt>().AvatarCamera = true;
                else if(gameObject.tag == "Player1units")
                    Players[0].gameObject.GetComponent<PlayerMovemnt>().AvatarCamera = false;
            else if (isSelected && gameObject.tag == "Player2units")
                Players[1].gameObject.GetComponent<PlayerMovemnt>().AvatarCamera = true;
            else if (gameObject.tag == "Player2units")
                Players[1].gameObject.GetComponent<PlayerMovemnt>().AvatarCamera = false;
                */
        }
        

    }
    
}
