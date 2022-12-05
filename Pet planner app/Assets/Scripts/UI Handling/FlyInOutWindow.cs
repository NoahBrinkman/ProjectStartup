using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FlyInOutWindow : MonoBehaviour
{
    [SerializeField] private Vector3 flyInPosition;
    private Vector3 flyOutPosition;
    [SerializeField] private Ease easeMode;
    [SerializeField] private float timeDuration;


    [SerializeField] private bool selectedToStart = false;
    
    private RectTransform rT;
    
    private void Start()
    {
        rT = GetComponent<RectTransform>();
        flyOutPosition = rT.position;
        if (selectedToStart)
        {
            rT.position = flyInPosition;
        }

    }

    public void FlyIn()
    {
        rT.DOMove(flyInPosition, timeDuration).SetEase(easeMode);
    }

    public void FlyOut()
    {
        rT.DOMove(flyOutPosition, timeDuration).SetEase(easeMode);
    }
    
}
