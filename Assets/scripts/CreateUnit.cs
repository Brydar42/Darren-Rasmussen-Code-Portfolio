using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//creats a unit from the start of the game
public class CreateUnit : NetworkBehaviour {
    //all the units
    public GameObject p1spearman;
    public GameObject p2spearman;
    public GameObject p1archer;
    public GameObject p2archer;
    public GameObject p1calvery;
    public GameObject p2calvery;
    //locations to spawn the units
    public Transform p1Area;
    public Transform p2Area;
    public List<PlayerController> Players = new List<PlayerController>();
    //adds the units spawns to the game win/lose player units tally
    public GameWinLossDecision toBeAdded;
    //a bool to 
    public bool readyToStart;
    // Use this for initialization
    void Start()
    {
        //players 0 = first player, players 1 = second player
        for (int i = 0; i < ClientScene.localPlayers.Count; i++)
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
                Debug.Log("PlayerAdded");
            }
        }
    }
        // Update is called once per frame
        void Update () {
        //unit is made into a game object and spawned
        for (int i = 0; i < ClientScene.localPlayers.Count; i++)
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
    }
    public void Spawnp1Spearman()
    {
        //if (Players[0].gameObject.GetComponent<PlayerMovemnt>().money > 10)
        //{
            GameObject unitspawned = Instantiate(p1spearman, p1Area.position, transform.rotation) as GameObject;
            NetworkServer.Spawn(unitspawned);
        //     Players[0].gameObject.GetComponent<PlayerMovemnt>().money -= 10;
        // }
        toBeAdded.Player1units += 1;
    }
    public void Spawnp2Spearman()
    {
       // if (Players[1].gameObject.GetComponent<PlayerMovemnt>().money > 10)
       // {
            GameObject unitspawned = Instantiate(p2spearman, p2Area.position, transform.rotation) as GameObject;
            NetworkServer.Spawn(unitspawned);
        //  Players[0].gameObject.GetComponent<PlayerMovemnt>().money -= 10;
        //}
        toBeAdded.Player2units += 1;
    }
    public void Spawnp1Archer()
    {
        //if (Players[0].gameObject.GetComponent<PlayerMovemnt>().money > 20)
       // {
            GameObject unitspawned = Instantiate(p1archer, p1Area.position, transform.rotation) as GameObject;
            NetworkServer.Spawn(unitspawned);
        //     Players[0].gameObject.GetComponent<PlayerMovemnt>().money -= 20;
        // }
        toBeAdded.Player1units += 1;
    }
    public void Spawnp2Archer()
    {
       // if (Players[0].gameObject.GetComponent<PlayerMovemnt>().money > 20)
       // {
            GameObject unitspawned = Instantiate(p2archer, p2Area.position, transform.rotation) as GameObject;
            NetworkServer.Spawn(unitspawned);
        //     Players[0].gameObject.GetComponent<PlayerMovemnt>().money -= 20;
        // }
        toBeAdded.Player2units += 1;
    }
    public void Spawnp1Calvery()
    {
        //if (Players[0].gameObject.GetComponent<PlayerMovemnt>().money > 30)
        //{

            GameObject unitspawned = Instantiate(p1calvery, p1Area.position, transform.rotation) as GameObject;
            NetworkServer.Spawn(unitspawned);
        //    Players[0].gameObject.GetComponent<PlayerMovemnt>().money -= 30;
        //}
        toBeAdded.Player1units += 1;
    }
    public void Spawnp2Calvery()
    {
        //if (Players[0].gameObject.GetComponent<PlayerMovemnt>().money > 30)
        //{
            GameObject unitspawned = Instantiate(p2calvery, p2Area.position, transform.rotation) as GameObject;
            NetworkServer.Spawn(unitspawned);
            Players[0].gameObject.GetComponent<PlayerMovemnt>().money -= 30;
        //}
        toBeAdded.Player2units += 1;
    }
    public void PressPlay()
    {
        //player who presses becomes ready
        //this statement changes the spawn phase to play phase
        foreach (PlayerController test in Players)
        {
            if (test.gameObject.GetComponent<PlayerMovemnt>().ready == true)
            {
                readyToStart = true;
            }
            //if a player is false don't bother looking to see if anyone else is done
            else
            {
                readyToStart = false;
                break;
            }

        }
       
    }
}
