using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTarget : MonoBehaviour
{
    [SerializeField] private VisualizedTask t;

    private void Start()
    {
        GetComponent<RectTransform>().sizeDelta *= (float)t.GetImportance() /2;
    }
}
