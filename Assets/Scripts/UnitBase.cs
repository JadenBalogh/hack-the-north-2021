using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UnitBase : UnitSpawner
{
    protected override void Die(int killerId)
    {
        base.Die(killerId);
        if (this == GameManager.GetLocalBase())
        {
            GameManager.Alive = false;
        }
        if (PhotonNetwork.IsMasterClient)
        {
            GameManager.RemainingPlayers.Remove(PlayerId);
            if (GameManager.RemainingPlayers.Count == 1)
            {
                int id = GameManager.RemainingPlayers[0];
                Player winner = PhotonNetwork.PlayerList[id - 1];
                photonView.RPC("GameOverRPC", RpcTarget.All, winner.NickName);
            }
        }
    }

    [PunRPC]
    public void GameOverRPC(string winner)
    {
        GameManager.OnGameOver.Invoke(winner);
    }
}
