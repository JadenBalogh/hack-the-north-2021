using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Action : ScriptableObject
{
    public ActionTag tag;
    public int manaCost;

    public void Invoke()
    {
        if (GameManager.ManaSystem.SpendMana(manaCost))
        {
            OnInvokeSuccess();
        }
    }

    protected abstract void OnInvokeSuccess();
}
