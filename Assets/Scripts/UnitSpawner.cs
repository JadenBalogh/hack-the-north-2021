using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    protected void Start()
    {
        OnPlayerIdChanged.AddListener((id) => ValidatePaths());
        ValidatePaths();
        StartCoroutine(SpawnUnitsLoop());
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

    private IEnumerator SpawnUnitsLoop()
    {
        while (true)
        {
            foreach (UnitPath path in paths)
            {
                if (!path.Active) continue;
                Unit unit = Instantiate(baseUnitPrefab, path.spawnpoint.position, Quaternion.identity);
                unit.SetPath(this, path.endpoint);
            }
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
