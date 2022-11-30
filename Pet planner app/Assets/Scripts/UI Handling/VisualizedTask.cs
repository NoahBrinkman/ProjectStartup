using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizedTask : MonoBehaviour
{
    [SerializeField] private Text nameTextfield;
    [SerializeField] private Text descriptionField;
    [SerializeField] private Text dueDateText;
    [SerializeField] private Text importanceText;
    [SerializeField] private Image colourImage;
    private Task selectedTask;
    
    public void Initialize(Task task)
    {
        selectedTask = task;

        nameTextfield.text = task.name;
        descriptionField.text = task.description;
        dueDateText.text = $"{task.dueDate.Day}/{task.dueDate.Month}/{task.dueDate.Year}";
        switch (task.importance)
        {
            case 1:
                importanceText.text = "Low Importance";
                break;
            case 2:
                importanceText.text = "Medium Importance";
                break;
            case 3:
                importanceText.text = "High Importance";
                break;
            default:
                importanceText.text = "No importance given";
                break;
        }

        switch (task.colour)
        {
            case Colour.green :
            {
                colourImage.color = TaskManager.Instance.green;
                break;
            }
            case Colour.yellow :
            {
                colourImage.color = TaskManager.Instance.yellow;
                break;
            }
            case Colour.blue :
            {
                colourImage.color = TaskManager.Instance.blue;
                break;
            }
            case Colour.pink :
            {
                colourImage.color = TaskManager.Instance.pink;
                break;
            }
        }
    }
    
    
}
