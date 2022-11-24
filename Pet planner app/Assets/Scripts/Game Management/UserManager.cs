using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class UserManager : MonoBehaviour
{
    [SerializeField] private int happinessValue;
    [SerializeField] private int hungerValue;
    [SerializeField] private int goldValue;
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
}
