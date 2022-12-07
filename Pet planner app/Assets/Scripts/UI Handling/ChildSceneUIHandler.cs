using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildSceneUIHandler : MonoBehaviour
{
    private float maxBarValue = 1;

    [SerializeField] private Image hungerBar;
    [SerializeField] private Image happinessBar;
    [SerializeField] private Text categoryText;
    public Image hat = null;
    public Image jacket = null;
    public Image accesory = null;

    public void SetCustomization(ItemInfo item)
    {
        if (item.category == ItemInfo.categories.Hats)
        {
            if (!hat.gameObject.activeSelf)
                hat.gameObject.SetActive(true);

            hat.sprite = item.visuals;
        }

        if (item.category == ItemInfo.categories.Jackets)
        {
            if (!jacket.gameObject.activeSelf)
                jacket.gameObject.SetActive(true);

            jacket.sprite = item.visuals;
        }

        if (item.category == ItemInfo.categories.Accesory)
        {
            if (!accesory.gameObject.activeSelf)
                accesory.gameObject.SetActive(true);

            accesory.sprite = item.visuals;
        }
    }
    private void Update()
    {
        UpdateBarValues();
    }

    public void UpdateCategory(ItemInfo.categories category)
    {
        categoryText.text = category.ToString();
    }
    private void UpdateBarValues()
    {
        hungerBar.fillAmount = UserManager.Instance.getHunger;
        happinessBar.fillAmount = UserManager.Instance.getHappy;

        if (UserManager.Instance.getHunger >= 0.8f && UserManager.Instance.getHappy < maxBarValue)
            UserManager.Instance.setHappy(Time.deltaTime / 100);

        if (UserManager.Instance.getHunger > 0)
            UserManager.Instance.setHunger(-(Time.deltaTime / 100));

        if (UserManager.Instance.getHunger <= 0.5f)
            UserManager.Instance.setHappy(-(Time.deltaTime / 100));

    }
}
