using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string name = String.Empty;
    public string description = String.Empty;
    public DateTime dueDate;
    public string importance;
    public Colour colour = Colour.None;

    public Task(string _name, string _description, DateTime _date,string _importance, Colour _colour)
    {
        name = _name;
        description = _description;
        dueDate = _date;
        importance = _importance;
        colour = _colour;
    }
}
