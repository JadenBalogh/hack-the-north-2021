using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManaSystem : MonoBehaviour
{
    [SerializeField] private int baseMaxMana;
    public int MaxMana { get; private set; }
    public int Mana { get; private set; }
    public UnityEvent<int> OnManaChanged { get; private set; }

    protected void Awake()
    {
        OnManaChanged = new UnityEvent<int>();
        MaxMana = baseMaxMana;
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
}
