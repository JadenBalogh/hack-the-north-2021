using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[CreateAssetMenu(fileName = "AreaFreezeAction", menuName = "Actions/AreaFreezeAction", order = 50)]
public class AreaFreezeAction : Action
{
    [SerializeField] private float duration = 1f;

    protected override void OnInvokeSuccess()
    {
        int localPlayerId = PhotonNetwork.LocalPlayer.ActorNumber;
        HashSet<Unit> units = new HashSet<Unit>();
        foreach (UnitSpawner building in GameManager.InfluenceSystem.GetOwnedBuildings())
        {
            Collider2D[] results = Physics2D.OverlapCircleAll(building.transform.position, building.InfluenceRadius);
            foreach (Collider2D col in results)
            {
                if (col.TryGetComponent<Unit>(out Unit unit) && unit.PlayerId != localPlayerId)
                {
                    units.Add(unit);
                }
            }
        }
        foreach (Unit unit in units)
        {
            unit.photonView.RPC("FreezeRPC", RpcTarget.MasterClient, duration);
        }
    }
}
