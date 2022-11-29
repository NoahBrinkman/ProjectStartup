using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class UserManager : MonoBehaviour
{
    [SerializeField] private int happinessValue;
    [SerializeField] private int hungerValue;
    [SerializeField] private int goldValue;

    public Image hat = null;
    const string HATS = "hats";
    public static UserManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public int getGold => goldValue;

    public void setGold(int amount)
    {
        goldValue += amount;
    }

    public void SetCustomization(ItemInfo item)
    {
        if (item.category == HATS)
            hat.sprite = item.visuals;
    }
}
