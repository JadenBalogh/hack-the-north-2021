using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : PlayerObject
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float enemyDetectRadius = 1f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackCooldown = 0.8f;

    private UnitSpawner origin;
    private UnitSpawner target;
    private PlayerObject currentEnemy;
    private bool canAttack = true;

    private Collider2D[] overlapResults = new Collider2D[50];
    private WaitForSeconds attackCooldownWait;

    protected override void Awake()
    {
        base.Awake();
        attackCooldownWait = new WaitForSeconds(attackCooldown);
    }

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
            if (canAttack)
            {
                StartCoroutine(AttackCooldown());
                currentEnemy.TakeDamage(PlayerId, damage);
            }
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

    protected override void Die(int killerId)
    {
        base.Die(killerId);
        Destroy(gameObject);
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
                currentEnemy.OnDeath.AddListener(() => currentEnemy = null);
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return attackCooldownWait;
        canAttack = true;
    }
}
