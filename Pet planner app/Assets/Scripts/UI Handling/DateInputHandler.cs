using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class DateInputHandler : MonoBehaviour
{
    private InputField inField;
    [SerializeField] private Text displayText;

    private DateTime date;
    public DateTime dateTime => date;
    void OnEnable()
    {
        inField = GetComponent<InputField>();
        inField.onValueChanged.AddListener(CheckFormat);
        inField.onSubmit.AddListener(validateDate);
    }

    private void validateDate(string input)
    {
        
        if (input.Length == 8)
        {
            int year = int.Parse(input.Substring(4));
            int day = int.Parse(input.Substring(0, 2));
            int month = int.Parse(input.Substring(2, 2));
            date = new DateTime(year, month, day);
            Debug.Log(date);
        }
        
    }

    private void CheckFormat(string input)
    {
        string newInput = String.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            newInput += input[i];
            if (i == 1 || i == 3)
            {
                newInput += '/';
            }
        }

        displayText.text = newInput;
    }

}
