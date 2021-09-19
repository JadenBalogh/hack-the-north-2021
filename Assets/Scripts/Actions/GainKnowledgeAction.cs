using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GainKnowledgeAction", menuName = "Actions/GainKnowledgeAction", order = 50)]
public class GainKnowledgeAction : Action
{
    private static int totalManaCostIncrement = 0;

    [SerializeField] private int manaCostIncrement;
    [SerializeField] private int maxManaBoost;
    [SerializeField] private int manaPerTickBoost;

    protected override int GetManaCost()
    {
        return base.GetManaCost() + totalManaCostIncrement;
    }

    protected override void OnInvokeSuccess()
    {
        totalManaCostIncrement += manaCostIncrement;
        GameManager.ManaSystem.BoostMaxMana(maxManaBoost);
        GameManager.ManaSystem.BoostManaPerTick(manaPerTickBoost);
    }
}
