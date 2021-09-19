using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UnitSpawner : PlayerObject
{
    [SerializeField] private UnitPath[] paths;
    public UnitPath[] Paths { get => paths; }

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
        bool isBase = GetType() == typeof(UnitBase);
        foreach (UnitPath path in paths)
        {
            bool prevActiveStatus = path.Active;
            bool newActiveStatus = isBase || IsEnemy(path.endpoint) || (PlayerId > 0 && IsPathTowardsEnemy(path));
            path.Active = newActiveStatus;
            if (prevActiveStatus != newActiveStatus)
            {
                path.endpoint.ValidatePaths();
            }
        }
    }

    public void SpawnUnit(string prefabName)
    {
        foreach (UnitPath path in paths)
        {
            if (!path.Active) continue;
            object[] obj = new object[]
            {
                photonView.ViewID,
                path.endpoint.photonView.ViewID
            };
            PhotonNetwork.Instantiate(prefabName, path.spawnpoint.position, Quaternion.identity, 0, obj);
        }
    }

    [PunRPC]
    public void SpawnUnitRPC(string prefabName)
    {
        SpawnUnit(prefabName);
    }

    protected override void Die(int killerId)
    {
        base.Die(killerId);
        PlayerId = killerId;
        ResetHealth();
    }

    private bool IsPathTowardsEnemy(UnitPath path) => IsPathTowardsEnemy(path, 0);

    private bool IsPathTowardsEnemy(UnitPath path, int count)
    {
        if (count > 5) return false;
        if (path.endpoint.TryGetComponent<UnitBase>(out UnitBase unitBase))
        {
            return unitBase.PlayerId != PlayerId;
        }
        foreach (UnitPath next in path.endpoint.Paths)
        {
            if (next.endpoint != this)
            {
                return IsPathTowardsEnemy(next, count + 1);
            }
        }
        return false;
    }

    private IEnumerator SpawnUnitsLoop()
    {
        while (true)
        {
            SpawnUnit(baseUnitPrefab.name);
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
