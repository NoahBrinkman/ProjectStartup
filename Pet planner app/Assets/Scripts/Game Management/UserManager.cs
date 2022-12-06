using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class UserManager : MonoBehaviour
{
    [SerializeField] private float happinessValue;
    [SerializeField] private float hungerValue;
    [SerializeField] private float goldValue;


    public static UserManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
            DontDestroyOnLoad(this);
        }
        else
        {
            Instance = this;
        }
    }


    

    public float getGold => goldValue;

    public float getHunger => hungerValue;

    public float getHappy => happinessValue;

    public void setGold(float amount)
    {
        goldValue += amount;
    }

    public void setHunger(float amount)
    {
        hungerValue += amount;
        hungerValue = Mathf.Clamp(hungerValue, 0, 1);
    }

    public void setHappy(float amount)
    {
        happinessValue += amount;
        happinessValue = Mathf.Clamp(happinessValue, 0, 1);
    }

    public void OnTaskCompleted(int importance)
    {
        goldValue += importance * 3;
    }
    
}
