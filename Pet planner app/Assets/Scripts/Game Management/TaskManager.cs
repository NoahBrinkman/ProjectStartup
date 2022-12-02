using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    
    public static TaskManager Instance { get; private set; }

    [SerializeField] private Color greenColour;
    [SerializeField] private Color yellowColour;
    [SerializeField] private Color blueColour;
    [SerializeField] private Color pinkColour;
    public Color green => greenColour;
    public Color yellow => yellowColour;
    public Color blue => blueColour;
    public Color pink => pinkColour;
    
    private List<Task> tasks = new List<Task>();
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        tasks.Sort();

    }

    public void SortTasks()
    {   
        tasks.Sort();
    }
    
    public Task GetTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            return tasks[index];
        }
        else
        {
            return null;
        }
    }
    
    public List<Task> GetTasks()
    {
       tasks.Sort();
       tasks.Reverse();
       return tasks;
    }
    
    public void AddTask(Task task)
    {
        //validate the task
        if (task.name == string.Empty || task.description == String.Empty || task.colour == Colour.None ||
            task.dueDate < DateTime.Today)
        {
            Debug.LogError("TASK IS INVALID");
        }
        else
        {
            tasks.Add(task);
        }
    }
}
