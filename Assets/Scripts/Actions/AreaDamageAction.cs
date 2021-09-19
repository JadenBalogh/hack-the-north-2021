using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[CreateAssetMenu(fileName = "AreaDamageAction", menuName = "Actions/AreaDamageAction", order = 50)]
public class AreaDamageAction : Action
{
    [SerializeField] private int damage = 1;

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
            unit.photonView.RPC("TakeDamageRPC", RpcTarget.All, localPlayerId, damage);
        }
    }
}
