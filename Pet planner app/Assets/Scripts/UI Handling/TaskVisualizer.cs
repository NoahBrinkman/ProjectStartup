using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskVisualizer : MonoBehaviour
{
    [SerializeField] private RectTransform container;
    [SerializeField] private GameObject taskPrefab;
    void Start()
    {
        List<Task> tasks = TaskManager.Instance.GetTasks();
        for (int i = 0; i < tasks.Count; i++)
        {
            GameObject o = Instantiate(taskPrefab, container);
            o.GetComponent<VisualizedTask>().Initialize(tasks[i]);
        }
    }
    
}
