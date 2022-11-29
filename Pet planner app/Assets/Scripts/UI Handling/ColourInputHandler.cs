using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum Colour
{
    None,
    green,
    pink,
    yellow,
    blue
}


public class ColourInputHandler : MonoBehaviour
{
    private Colour selectedColour;
    public Colour SelectedColour => selectedColour;
    public void SelectColour(ColourButton colour)
    {
        if (colour.color != Colour.None)
        {
            selectedColour = colour.color;
        }
       // Debug.Log(selectedColour);
    }
    
}
