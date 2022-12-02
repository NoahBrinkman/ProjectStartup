using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : IComparable<Task>
{
    public string name = String.Empty;
    public string description = String.Empty;
    public DateTime dueDate;
    public int importance;
    public Colour colour = Colour.None;

    public bool isCompleted = false;
    
    public Task(string _name, string _description, DateTime _date,int  _importance, Colour _colour)
    {
        name = _name;
        description = _description;
        dueDate = _date;
        importance = _importance;
        colour = _colour;
    }
    
    public int CompareTo(Task t)
    {
        int score = 0;
        int scoreT = 0;
        if (importance > t.importance)
        {
            score += 1;
        }
        else if (importance < t.importance)
        {
            scoreT += 1;
        }

        if (dueDate < t.dueDate)
        {
            score += 10;
        }
        else if (dueDate > t.dueDate)
        {
            scoreT += 10;
        }


        if (score > scoreT)
        {
            return 1;
        }else if (score == scoreT)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}
