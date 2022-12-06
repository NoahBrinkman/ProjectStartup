using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ExpandBob : MonoBehaviour
{
    [SerializeField] private float durationInSeconds;
    [SerializeField] private Image bob;
    [SerializeField] private Image backGroundImage;
    [SerializeField] private float endScale = 1.5f;
    [SerializeField] private float endPosY = 15;
    [SerializeField] private float endPosBobY = 1000;
    [SerializeField] private float endPosBGY = 1000;
    public void Expand()
    {
        GetComponent<RectTransform>().DOMoveY(endPosY, durationInSeconds);
        GetComponent<RectTransform>().DOSizeDelta(new Vector2(520, endScale), durationInSeconds);
        backGroundImage.GetComponent<RectTransform>().DOMoveY(endPosBGY, durationInSeconds);
        bob.GetComponent<RectTransform>().DOMoveY(endPosBobY, durationInSeconds);
    }

    public void Deflate()
    {
        GetComponent<RectTransform>().DOMoveY(2150, durationInSeconds);
        GetComponent<RectTransform>().DOSizeDelta(new Vector2(520, 436), durationInSeconds);
        backGroundImage.GetComponent<RectTransform>().DOMoveY(endPosBGY+995, durationInSeconds);
        bob.GetComponent<RectTransform>().DOMoveY(2000, durationInSeconds);
    }
}
