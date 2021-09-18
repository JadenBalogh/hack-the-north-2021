using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Transform target;

    private void Update()
    {
        if (target != null && !Utils.InRange(transform, target, 0.01f))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
