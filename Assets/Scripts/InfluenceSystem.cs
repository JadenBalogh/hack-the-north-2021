using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InfluenceSystem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer influenceZonePrefab;

    private HashSet<int> ownedBuildingIds;
    private UnitSpawner[] buildings;
    private SpriteRenderer[] influenceZones;

    protected void Start()
    {
        ownedBuildingIds = new HashSet<int>();
        buildings = GameObject.FindObjectsOfType<UnitSpawner>();
        influenceZones = new SpriteRenderer[buildings.Length];

        for (int i = 0; i < buildings.Length; i++)
        {
            UnitSpawner building = buildings[i];

            // Setup building list
            building.OnPlayerIdChanged.AddListener((id) => UpdateOwnedBuildings());
            bool isMyBuilding = building.PlayerId == PhotonNetwork.LocalPlayer.ActorNumber;
            if (isMyBuilding) ownedBuildingIds.Add(i);

            // Setup influence zones
            influenceZones[i] = Instantiate(influenceZonePrefab, building.transform.position, Quaternion.identity);
            influenceZones[i].transform.localScale = new Vector2(building.InfluenceRadius, building.InfluenceRadius);
            influenceZones[i].enabled = isMyBuilding;
        }
    }

    public List<UnitSpawner> GetOwnedBuildings()
    {
        List<UnitSpawner> results = new List<UnitSpawner>();
        foreach (int id in ownedBuildingIds)
        {
            results.Add(buildings[id]);
        }
        return results;
    }

    private void UpdateOwnedBuildings()
    {
        for (int i = 0; i < buildings.Length; i++)
        {
            bool isMine = buildings[i].PlayerId == PhotonNetwork.LocalPlayer.ActorNumber;
            if (isMine) ownedBuildingIds.Add(i);
            else ownedBuildingIds.Remove(i);

            influenceZones[i].enabled = isMine;
        }
    }
}
