using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : PlayerObject
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float enemyDetectRadius = 1f;

    private UnitSpawner origin;
    private UnitSpawner target;
    private PlayerObject currentEnemy;

    private Collider2D[] overlapResults = new Collider2D[50];

    protected void Update()
    {
        // Check for enemy in range
        if (currentEnemy == null)
        {
            FindNearestEnemy();
        }

        if (currentEnemy != null)
        {
            // Attack current enemy if valid
            
        }
        else if (target != null)
        {
            // Move towards the target spawner
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

    private void FindNearestEnemy()
    {
        int numResults = Physics2D.OverlapCircleNonAlloc(transform.position, enemyDetectRadius, overlapResults);
        for (int i = 0; i < numResults; i++)
        {
            Collider2D col = overlapResults[i];
            if (col.TryGetComponent<PlayerObject>(out PlayerObject obj) && IsEnemy(obj))
            {
                currentEnemy = obj;
            }
        }
    }
}
