using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InfluenceSystem : MonoBehaviour
{
    public List<UnitSpawner> OwnedBuildings { get; private set; }

    protected void Awake()
    {
        OwnedBuildings = new List<UnitSpawner>();
    }

    protected void Start()
    {
        UnitSpawner[] buildings = GameObject.FindObjectsOfType<UnitSpawner>();
        foreach (UnitSpawner building in buildings)
        {
            building.OnPlayerIdChanged.AddListener((id) => UpdateOwnedBuildings(building, id));
        }
    }

    private void UpdateOwnedBuildings(UnitSpawner building, int playerId)
    {
        bool isNowOwned = playerId == PhotonNetwork.LocalPlayer.ActorNumber;
        if (isNowOwned) OwnedBuildings.Add(building);
        else OwnedBuildings.Remove(building);
    }
}
