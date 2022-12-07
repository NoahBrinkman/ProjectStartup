using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VisualizedTask : MonoBehaviour
{
    [SerializeField] private Text nameTextfield;
    public Text NameTextField => nameTextfield;
    [SerializeField] private Text descriptionField;
    public Text DescriptionTextField => descriptionField;
    [SerializeField] private Text dueDateText;
    public Text DueDateText => dueDateText;
    [SerializeField] private Text importanceText;
    [SerializeField] private Image colourImage;
    [SerializeField] private Toggle toggle;
    private Task selectedTask;
    
    [SerializeField] private bool parentShouldBeCanvas = false;
    [SerializeField] private bool turnOffToggle = false;
    [SerializeField] private bool isPopUp = false;
    public UnityEvent OnCompleted;

    public int GetImportance()
    {
        return selectedTask.importance;
    }
    
    public void Initialize(Task task)
    {
        if(turnOffToggle) toggle.gameObject.SetActive(false);
        if (parentShouldBeCanvas)
        {
            RectTransform rT = GetComponent<RectTransform>();
            SetParentToCanvas(rT.position, rT.sizeDelta);
        }
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
        if (UserManager.Instance != null)
        {
            OnCompleted.AddListener(delegate { UserManager.Instance.OnTaskCompleted(selectedTask.importance); });
            OnCompleted.AddListener(delegate { TaskManager.Instance.OnTaskCompleted(selectedTask); });
        }
    }
    
    public void SetComplete()
    {
        if(selectedTask == null) return;
        
        selectedTask.isCompleted = toggle.isOn;
        if (selectedTask.isCompleted)
        {
            OnCompleted?.Invoke();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isPopUp)
        {
            GetComponent<PopupWIndow>().DisableWithTween();
            
        }
    }

    public void SetParentToCanvas(Vector3 savedPosition, Vector2 savedSize)
    {
        do
        {
            transform.SetParent(transform.parent.parent, false);
        } while (transform.parent.GetComponent<Canvas>() == null);

      /* RectTransform rT = GetComponent<RectTransform>();
       rT.position = savedPosition;
       rT.sizeDelta = savedSize;*/
    }

}
