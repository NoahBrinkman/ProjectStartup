using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<ItemInfo> shopItems = new List<ItemInfo>();
    [SerializeField] private GameObject shopItemPrefab = null;
    [SerializeField] private List<GameObject> shopItemButtons = new List<GameObject>();

    private void Start()
    {
        foreach (ItemInfo item in shopItems)
        {
            GameObject newShopItem = Instantiate(shopItemPrefab);
            newShopItem.GetComponent<Button>().interactable = !item.bought;
            newShopItem.GetComponent<Button>().onClick.AddListener(BuyItem);
            newShopItem.GetComponentInChildren<Text>().text = item.price.ToString();
            newShopItem.transform.SetParent(transform, false);
            shopItemButtons.Add(newShopItem);
        }
    }

    private void BuyItem()
    {

    }
}
