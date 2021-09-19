using UnityEngine;
using Photon.Pun;

[CreateAssetMenu(fileName = "SpawnUnitsAction", menuName = "Actions/SpawnUnitsAction", order = 50)]
public class SpawnUnitsAction : Action
{
    [SerializeField] private Unit unitPrefab;

    protected override void OnInvokeSuccess()
    {
        UnitSpawner localBase = GameManager.GetLocalBase();
        localBase.photonView.RPC("SpawnUnitRPC", RpcTarget.MasterClient, unitPrefab.name);
    }
}
