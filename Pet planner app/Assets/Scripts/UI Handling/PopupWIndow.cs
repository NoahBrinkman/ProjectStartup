using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class PopupWIndow : MonoBehaviour
{
    [SerializeField] private Vector3 popUpEndScale = new Vector3(1,1,1);
    [SerializeField] private Vector3 popUpStartScale = new Vector3(.2f,.2f,.2f);
    [SerializeField] private float popUpDuration = 1.0f;
    [SerializeField] private Ease easeMode;

    private RectTransform rTransform;
    private void OnEnable()
    {
        rTransform = GetComponent<RectTransform>();
        rTransform.DOScale(popUpEndScale, popUpDuration).SetEase(easeMode);
    }


    public void DisableWithTween()
    {
        Tween t =  rTransform.DOScale(new Vector3(), popUpDuration).SetEase(easeMode);
        t.onComplete += delegate { rTransform.localScale = popUpStartScale; };
        t.onComplete += delegate { gameObject.SetActive(false); };
        t.Play();
    }
    
}
