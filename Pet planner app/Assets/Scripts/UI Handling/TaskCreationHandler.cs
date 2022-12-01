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
        Debug.Log(taskCreated.name);
        Debug.Log(taskCreated.description);
        Debug.Log(taskCreated.dueDate);
        Debug.Log(taskCreated.colour);
    }
    
}
