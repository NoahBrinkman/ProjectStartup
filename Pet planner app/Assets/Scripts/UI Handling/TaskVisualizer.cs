using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TaskVisualizer : MonoBehaviour
{
    [SerializeField] private RectTransform container;
    [SerializeField] private List<GameObject> taskPrefabs;

    [SerializeField] private Image createTaskPrompt;
    
    void Start()
    {
        CheckForTasks();
    }

    public void CheckForTasks()
    {
        List<Task> tasks = TaskManager.Instance.GetTasks();
        createTaskPrompt.gameObject.SetActive(false);
        if (container.transform.childCount > 0)
        {
            foreach (Transform t in container.transform)
            {
                GameObject.Destroy(t.gameObject);
            }

        }
        if (tasks.Count != 0)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                GameObject o = Instantiate(taskPrefabs[Random.Range(0,taskPrefabs.Count)], container);
                o.GetComponentInChildren<VisualizedTask>(true).Initialize(tasks[i]);
            }
        }
        else
        {
            createTaskPrompt.gameObject.SetActive(true);
        }
    }
}
