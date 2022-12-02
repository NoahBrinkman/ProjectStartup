using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskCreationHandler : MonoBehaviour
{
    public Task taskCreated;

    [SerializeField] private InputField nameInput;
    [SerializeField] private InputField descriptionInput;
    [SerializeField] private DateInputHandler dateInput;
    [SerializeField] private Dropdown importanceInput;
    [SerializeField] private ColourInputHandler colourInput;
    
    public void CreateTask()
    {
        taskCreated = new Task(nameInput.text, descriptionInput.text, dateInput.dateTime, 
            importanceInput.value + 1, colourInput.SelectedColour);
        TaskManager.Instance.AddTask(taskCreated);
        nameInput.text = String.Empty;
        descriptionInput.text = String.Empty;
        dateInput.ClearInput();
        importanceInput.value = 0;
    }
    
}
