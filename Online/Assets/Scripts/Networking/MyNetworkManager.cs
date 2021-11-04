using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        var newPlayer = conn.identity.GetComponent<Player>();

        newPlayer.UpdateName($"Player{numPlayers}");

        newPlayer.ChangeColor();


    }

}
