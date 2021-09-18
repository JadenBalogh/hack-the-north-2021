using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private UnitSpawner[] bases;

    public override void OnPlayerEnteredRoom(Player player)
    {
        Debug.Log(player.NickName + " joined the room!");
    }
}
