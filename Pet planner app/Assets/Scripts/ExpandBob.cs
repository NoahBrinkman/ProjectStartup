using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ExpandBob : MonoBehaviour
{
    [SerializeField] private float durationInSeconds;
    [SerializeField] private Image bob;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Deflate();
    }

    public void Expand()
    {
        GetComponent<RectTransform>().DOScaleY(2.16f, durationInSeconds);
        bob.GetComponent<RectTransform>().DOMoveY(1280,durationInSeconds);
    }

    public void Deflate()
    {
        GetComponent<RectTransform>().DOScaleY(1f, durationInSeconds);
        bob.GetComponent<RectTransform>().DOMoveY(1820, durationInSeconds);
    }
}
