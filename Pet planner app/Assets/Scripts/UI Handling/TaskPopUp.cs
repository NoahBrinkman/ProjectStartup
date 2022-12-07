using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPopUp : PopupWIndow
{
    private VisualizedTask selectedTask;
    [SerializeField] private Text taskname;
    [SerializeField] private Text description;
    [SerializeField] private Text dueDate;
    [SerializeField] private bool disableOnClick;
    public void SetTask(VisualizedTask selectedTask)
    {
        taskname.text = selectedTask.NameTextField.text;
        description.text = selectedTask.DescriptionTextField.text;
        dueDate.text = selectedTask.DueDateText.text;
    }

    private void Update()
    {
        if (disableOnClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DisableWithTween();
            }
        }
    }
}
