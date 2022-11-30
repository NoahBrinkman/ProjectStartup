using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<ItemInfo> shopItems = new List<ItemInfo>();
    [SerializeField] private GameObject shopItemPrefab = null;

    private Button hatSelectedButton;
    private Button jacketSelectedButton;

    private void Start()
    {
        foreach (ItemInfo item in shopItems)
        {
            GameObject newShopItem = Instantiate(shopItemPrefab);
            newShopItem.GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item); });
            newShopItem.GetComponentInChildren<Text>().text = item.price.ToString();
            newShopItem.transform.SetParent(transform, false);
        }
    }

    private void BuyItem(ItemInfo item)
    {
        Button button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if (UserManager.Instance.getGold >= item.price &&
            button.GetComponent<Outline>().effectColor == Color.black)
        {
            UserManager.Instance.setGold(-item.price);
            button.GetComponent<Outline>().effectColor = Color.green;
            button.onClick.AddListener(delegate { EquipItem(item); });
        }
    }

    private void EquipItem(ItemInfo item)
    {
        Button button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

        if (hatSelectedButton != null && item.category == ItemInfo.categories.hats)
            hatSelectedButton.GetComponent<Outline>().effectColor = Color.green;

        if (item.category == ItemInfo.categories.hats)
            hatSelectedButton = button;

        if (jacketSelectedButton != null && item.category == ItemInfo.categories.jackets)
            jacketSelectedButton.GetComponent<Outline>().effectColor = Color.green;

        if (item.category == ItemInfo.categories.jackets)
            jacketSelectedButton = button;

        UserManager.Instance.SetCustomization(item);
        button.GetComponent<Outline>().effectColor = Color.blue;
    }
}
