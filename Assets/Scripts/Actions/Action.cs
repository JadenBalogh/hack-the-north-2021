using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Action : ScriptableObject
{
    [SerializeField] private ActionTag tag;
    public ActionTag Tag { get => tag; }

    [SerializeField] private int manaCost;

    public void Invoke()
    {
        if (GameManager.ManaSystem.SpendMana(GetManaCost()))
        {
            OnInvokeSuccess();
        }
    }

    protected virtual int GetManaCost() => manaCost;

    protected abstract void OnInvokeSuccess();
}
