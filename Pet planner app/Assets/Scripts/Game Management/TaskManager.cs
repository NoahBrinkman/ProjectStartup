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
    
    private List<Task> tasks;
    
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

        tasks = new List<Task>();
        
        tasks.Add(new Task("2nd", "this should be second", new DateTime(2022,4,5),3, Colour.green));
        tasks.Add(new Task("1st", "this should be second", new DateTime(2022,3,5),3, Colour.green));
        tasks.Add(new Task("4th", "this should be second", new DateTime(2022,3,5),1, Colour.green));
        tasks.Add(new Task("3rd", "this should be second", new DateTime(2022,3,5),2, Colour.green));
        
        tasks.Sort();
        for (int i = tasks.Count -1; i > -1; i--)
        {
            Debug.Log(tasks[i].name);
        }
    }

    public void SortTasks()
    {/*
        IEnumerable<Task> uncompleteTasks = tasks.Where(x => !x.isCompleted);
        IEnumerable<Task> highImportance = uncompleteTasks.Where(x => x.importance == "High importance").OrderBy(y => y.dueDate);
        IEnumerable<Task> medImportance = uncompleteTasks.Where(x => x.importance == "Medium importance").OrderBy(y => y.dueDate);
        IEnumerable<Task> lowImportance = uncompleteTasks.Where(x => x.importance == "Low importance").OrderBy(y => y.dueDate);

        highImportance.Concat(medImportance);
        highImportance.Concat(lowImportance);

        IEnumerable<Task> completeTasks = tasks.Where(x => x.isCompleted);
        highImportance.Concat(completeTasks);
        return highImportance.ToList();*/
        
        
        tasks.Sort();
        //uncompleteTasks = uncompleteTasks.OrderBy(x => x.dueDate).ToList();
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
        
    }
}
