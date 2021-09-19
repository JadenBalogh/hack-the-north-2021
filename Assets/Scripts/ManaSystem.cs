using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManaSystem : MonoBehaviour
{
    [SerializeField] private int baseMaxMana = 100;
    public int MaxMana { get; private set; }
    public int Mana { get; private set; }
    public UnityEvent<int> OnManaChanged { get; private set; }

    [SerializeField] private int baseManaPerTick = 2;
    public int ManaPerTick { get; private set; }

    [SerializeField] private int baseManaTickInterval = 1;
    public int ManaTickInterval { get; private set; }

    protected void Awake()
    {
        OnManaChanged = new UnityEvent<int>();
        MaxMana = baseMaxMana;
        ManaPerTick = baseManaPerTick;
        ManaTickInterval = baseManaTickInterval;
    }

    protected void Start()
    {
        StartCoroutine(PassiveManaTick());
    }

    public void BoostMaxMana(int boost)
    {
        MaxMana += boost;
    }

    public void BoostManaPerTick(int boost)
    {
        ManaPerTick += boost;
    }

    public void AddMana(int amount)
    {
        Mana = Mathf.Clamp(Mana + amount, 0, MaxMana);
        OnManaChanged.Invoke(Mana);
    }

    public bool SpendMana(int amount)
    {
        bool canAfford = Mana - amount >= 0;
        if (canAfford)
        {
            Mana -= amount;
            OnManaChanged.Invoke(Mana);
        }
        return canAfford;
    }

    private IEnumerator PassiveManaTick()
    {
        while (true)
        {
            AddMana(ManaPerTick);
            yield return new WaitForSeconds(ManaTickInterval);
        }
    }
}
