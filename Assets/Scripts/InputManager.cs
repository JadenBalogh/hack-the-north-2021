using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    InputField inputField;

    private string currentString = "";

    public List<GameObject> textElements;

    public string[] wordList;

    public delegate void ActionCallback();

    public List<ActionCallback> callbacks = new List<ActionCallback>() { PlaceholderCallbacks.Callback1, PlaceholderCallbacks.Callback2, PlaceholderCallbacks.Callback3, PlaceholderCallbacks.Callback4 };

    void Start()
    {
        inputField = GetComponentInChildren<InputField>();
        inputField.Select();
        inputField.ActivateInputField();
        RestTexts();
    }

    public void ReadInput(string myStr)
    {
        // On escape key pressed, reset everything
        if (myStr == "")
        {
            currentString = "";
            RestTexts();
            inputField.Select();
            inputField.ActivateInputField();
            return;
        }

        char lastTyped = myStr[myStr.Length - 1];
        currentString += lastTyped;

        bool noMatch = true;

        for (int i = 0; i < textElements.Count; i++)
        {
            string currentWord = wordList[i];
            if (currentString.Length <= currentWord.Length && currentString == currentWord.Substring(0, currentString.Length))
            {
                noMatch = false;

                if (currentString == currentWord)
                {
                    callbacks[i]();
                    currentString = "";
                    RestTexts();
                }
                else
                {
                    string moreGreen = GetStringWithGreenUpTo(currentWord, currentString.Length);
                    textElements[i].GetComponent<Text>().text = moreGreen;
                }
            }
        }

        if (noMatch)
        {
            currentString = currentString.Substring(0, currentString.Length - 1);
        }
    }

    void RestTexts()
    {
        for (int i = 0; i < textElements.Count; i++)
        {
            textElements[i].GetComponent<Text>().text = wordList[i];
        }

    }

    string GetStringWithGreenUpTo(string input, int max)
    {
        string result = "<color=green>";
        result += input.Substring(0, max);
        result += "</color>";
        result += input.Substring(max);
        return result;
    }
}
