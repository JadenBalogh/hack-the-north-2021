using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    InputField inputField;

    void Start()
    {
        inputField = GetComponent<InputField>();
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void ReadInput(string myStr)
    {

        Debug.Log(myStr);
    }
}
