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
        if (TaskManager.Instance == null)
        {
            Debug.LogWarning("No TaskManager Found");
            return;
        }
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
                if(tasks[i].isCompleted) continue;
                
                GameObject o = Instantiate(taskPrefabs[Random.Range(0,taskPrefabs.Count)], container);
                o.GetComponentInChildren<VisualizedTask>(true).Initialize(tasks[i]);
                o.GetComponentInChildren<VisualizedTask>(true)?.OnCompleted.AddListener(delegate { CheckForTasks(); });
            }
        }
        else
        {
            createTaskPrompt.gameObject.SetActive(true);
        }
    }
}
