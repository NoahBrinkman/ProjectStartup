using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskVisualizer : MonoBehaviour
{
    [SerializeField] private RectTransform container;
    [SerializeField] private GameObject taskPrefab;

    [SerializeField] private Image createTaskPrompt;
    
    void Start()
    {
        List<Task> tasks = TaskManager.Instance.GetTasks();
        if (tasks.Count != 0)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                GameObject o = Instantiate(taskPrefab, container);
                o.GetComponent<VisualizedTask>().Initialize(tasks[i]);
            }
        }
        else
        {
            createTaskPrompt.gameObject.SetActive(true);
        }
    }
    
}
