using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaText : MonoBehaviour
{
    private TextMeshProUGUI textbox;

    protected void Start()
    {
        textbox = GetComponent<TextMeshProUGUI>();
        GameManager.ManaSystem.OnManaChanged.AddListener(UpdateManaText);
    }

    private void UpdateManaText(int mana)
    {
        textbox.text = "" + mana + "/" + GameManager.ManaSystem.MaxMana;
    }
}
