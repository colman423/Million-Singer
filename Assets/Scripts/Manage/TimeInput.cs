using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeInput : MonoBehaviour
{
    public void format(string input)
    {
        if (input.Length == 0 || input.IndexOf("-") != -1)
        {
            input = "0";
        }
        if (input.Length == 1)
        {
            gameObject.GetComponent<InputField>().text = "0" + input;
        }
        if (gameObject.name == "sec") maxSec(gameObject.GetComponent<InputField>().text);
    }
    public void maxSec(string input)
    {
        int num = Int16.Parse(input);
        if (num > 59)
        {
            gameObject.GetComponent<InputField>().text = "59";
        }
    }
}
