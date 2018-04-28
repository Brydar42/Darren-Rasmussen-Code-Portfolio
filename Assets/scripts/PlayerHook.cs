using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

using Prototype.NetworkLobby;

public class PlayerHook : LobbyHook {

    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        //sets gameplayer player number to eqaul lobby number
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        PlayerMovemnt playerMovement = gamePlayer.GetComponent<PlayerMovemnt>();
        playerMovement.StoredPlayerNumber = lobby.PlayerNumber;
        //gamePlayer.GetComponent<PlayerMovemnt>().StoredPlayerNumber = lobbyPlayer.GetComponent<LobbyPlayer>().PlayerNumber;
    }
}
