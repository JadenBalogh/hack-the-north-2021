using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionText : MonoBehaviour
{
    [SerializeField] private ActionTag actionTag;

    private TextMeshProUGUI textbox;

    protected void Start()
    {
        textbox = GetComponent<TextMeshProUGUI>();
        GameManager.ActionSystem.OnActionInvoked.AddListener(DisplayActivation);
        UpdateManaText(GameManager.ActionSystem.GetAction(actionTag).ManaCost);
    }

    private void DisplayActivation(Action action)
    {
        // TODO
    }

    private void UpdateManaText(int mana)
    {
        textbox.text = "" + mana + "<color=#B400FF>•</color>";
    }
}
