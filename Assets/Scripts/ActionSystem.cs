using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionSystem : MonoBehaviour
{
    [SerializeField] private Action[] actions;

    private Dictionary<ActionTag, Action> actionTargets = new Dictionary<ActionTag, Action>();

    protected void Awake()
    {
        foreach (Action action in actions)
        {
            actionTargets.Add(action.Tag, action);
        }
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeAction(ActionTag.SpawnBasicUnits);
        }
    }

    public void InvokeAction(ActionTag tag)
    {
        actionTargets[tag].Invoke();
    }
}
