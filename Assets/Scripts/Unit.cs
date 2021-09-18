using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private UnitSpawner origin;
    private UnitSpawner target;

    private void Update()
    {
        // Move towards the target spawner
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            if (Utils.InRange(transform, target.transform, 0.01f))
            {
                UnitSpawner nextSpawner = target.GetNextSpawner(origin);
                origin = target;
                target = nextSpawner;
            }
        }
    }

    public void SetPath(UnitSpawner origin, UnitSpawner target)
    {
        this.origin = origin;
        this.target = target;
    }
}
