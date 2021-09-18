using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnBasicUnitsAction", menuName = "Actions/SpawnBasicUnitsAction", order = 50)]
public class SpawnBasicUnitsAction : Action
{
    [SerializeField] private Unit unitPrefab;

    protected override void OnInvokeSuccess()
    {
        UnitSpawner localBase = GameManager.GetLocalBase();
        localBase.SpawnUnit(unitPrefab);
    }
}
