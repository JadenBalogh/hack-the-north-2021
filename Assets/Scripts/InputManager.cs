using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    InputField inputField;

    private string currentString = "";

    public List<GameObject> textElements;

    string[] myList = new string[] { "test text", "tyui", "opas", "chaeyoungfromtwice" };

    void Start()
    {
        inputField = GetComponentInChildren<InputField>();
        inputField.Select();
        inputField.ActivateInputField();
        for (int i = 0; i < textElements.Count; i++)
        {
            textElements[i].GetComponent<Text>().text = myList[i];
        }
    }

    public void ReadInput(string myStr)
    {
        char lastTyped = myStr[myStr.Length - 1];
        for (int i = 0; i < textElements.Count; i++)
        {
            string currentWord = myList[i];
            if (currentWord[currentString.Length] == lastTyped)
            {
                currentString += lastTyped;
                string moreGreen = GetStringWithGreenUpTo(currentWord, currentString.Length);
                textElements[i].GetComponent<Text>().text = moreGreen;
            }
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
