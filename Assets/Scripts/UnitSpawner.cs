using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private UnitPath[] paths;
    [SerializeField] private Unit baseUnitPrefab;
    [SerializeField] private float baseSpawnRate = 1f;

    private WaitForSeconds baseSpawnRateWait;

    private void Awake()
    {
        baseSpawnRateWait = new WaitForSeconds(baseSpawnRate);
    }

    private void Start()
    {
        StartCoroutine(SpawnUnitsLoop());
    }

    private IEnumerator SpawnUnitsLoop()
    {
        while (true)
        {
            foreach (UnitPath path in paths)
            {
                Unit unit = Instantiate(baseUnitPrefab, path.spawnpoint.position, Quaternion.identity);
                unit.SetTarget(path.endpoint);
            }
            yield return baseSpawnRateWait;
        }
    }

    [System.Serializable]
    public class UnitPath
    {
        public Transform spawnpoint;
        public Transform endpoint;

        public bool Active { get; set; }
    }
}
