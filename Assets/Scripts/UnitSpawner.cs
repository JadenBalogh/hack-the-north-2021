using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UnitSpawner : PlayerObject
{
    [SerializeField] private UnitPath[] paths;
    [SerializeField] private Unit baseUnitPrefab;
    [SerializeField] private float baseSpawnRate = 1f;

    private WaitForSeconds baseSpawnRateWait;

    protected override void Awake()
    {
        base.Awake();
        baseSpawnRateWait = new WaitForSeconds(baseSpawnRate);
    }

    protected override void Start()
    {
        base.Start();
        OnPlayerIdChanged.AddListener((id) => ValidatePaths());
        ValidatePaths();

        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(SpawnUnitsLoop());
        }
    }

    public UnitSpawner GetNextSpawner(UnitSpawner origin)
    {
        foreach (UnitPath path in paths)
        {
            if (path.endpoint != origin)
            {
                return path.endpoint;
            }
        }
        return origin;
    }

    ///<summary>Checks the alliance of all connected paths and updates path Active status accordingly.</summary>
    public void ValidatePaths()
    {
        foreach (UnitPath path in paths)
        {
            bool prevActiveStatus = path.Active;
            bool newActiveStatus = IsEnemy(path.endpoint);
            path.Active = newActiveStatus;
            if (prevActiveStatus != newActiveStatus)
            {
                path.endpoint.ValidatePaths();
            }
        }
    }

    public void SpawnUnit(Unit prefab)
    {
        foreach (UnitPath path in paths)
        {
            if (!path.Active) continue;
            object[] obj = new object[]
            {
                photonView.ViewID,
                path.endpoint.photonView.ViewID
            };
            PhotonNetwork.Instantiate(prefab.name, path.spawnpoint.position, Quaternion.identity, 0, obj);
        }
    }

    protected override void Die(int killerId)
    {
        base.Die(killerId);
        PlayerId = killerId;
        ResetHealth();
    }

    private IEnumerator SpawnUnitsLoop()
    {
        while (true)
        {
            SpawnUnit(baseUnitPrefab);
            yield return baseSpawnRateWait;
        }
    }

    [System.Serializable]
    public class UnitPath
    {
        public Transform spawnpoint;
        public UnitSpawner endpoint;

        public bool Active { get; set; }
    }
}
