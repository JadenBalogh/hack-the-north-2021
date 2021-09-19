using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private RectTransform barFill;

    protected void Start()
    {
        GameManager.ManaSystem.OnManaChanged.AddListener(UpdateManaBar);
    }

    private void UpdateManaBar(int mana)
    {
        barFill.anchorMax = new Vector2((float)mana / GameManager.ManaSystem.MaxMana, 1);
    }
}
