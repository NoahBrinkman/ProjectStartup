using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class UserManager : MonoBehaviour
{
    [SerializeField] private float happinessValue;
    [SerializeField] private float hungerValue;
    [SerializeField] private int goldValue;

    private float maxBarValue = 1;

    [SerializeField] private Image hungerBar;
    [SerializeField] private Image happinessBar;
    public Image hat = null;
    public Image jacket = null;
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

    private void Update()
    {

        // temp for feed
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Feed(0.1f);
        }

        UpdateBarValues();
    }

    private void Feed(float foodValue)
    {
        if (hungerValue <= maxBarValue)
            hungerValue += foodValue;
    }

    private void UpdateBarValues()
    {
        hungerBar.fillAmount = hungerValue;
        happinessBar.fillAmount = happinessValue;

        if (hungerValue >= 0.8f && happinessValue < maxBarValue)
            happinessValue += Time.deltaTime / 100;

        if (hungerValue > 0)
            hungerValue -= Time.deltaTime / 100;

        if (hungerValue <= 0.5f)
            happinessValue -= Time.deltaTime / 100;

    }

    public int getGold => goldValue;

    public void setGold(int amount)
    {
        goldValue += amount;
    }

    public void SetCustomization(ItemInfo item)
    {
        if (item.category == ItemInfo.categories.hats)
        {
            if (!hat.gameObject.activeSelf)
                hat.gameObject.SetActive(true);

            hat.sprite = item.visuals;
        }

        if (item.category == ItemInfo.categories.jackets)
        {
            if (!jacket.gameObject.activeSelf)
                jacket.gameObject.SetActive(true);

            jacket.sprite = item.visuals;
        }
    }
}
