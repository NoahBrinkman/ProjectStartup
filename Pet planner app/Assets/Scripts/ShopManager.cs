using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<ItemInfo> currentList = new List<ItemInfo>();
    private List<GameObject> currentShopObjects = new List<GameObject>();

    [SerializeField] private List<ItemInfo> hatList = new List<ItemInfo>();
    [SerializeField] private List<ItemInfo> jacketList = new List<ItemInfo>();
    [SerializeField] private List<ItemInfo> accesoryList = new List<ItemInfo>();
    [SerializeField] private List<ItemInfo> foodList = new List<ItemInfo>();

    private List<List<ItemInfo>> categoryLists = new List<List<ItemInfo>>();
    private int categoryIndex = 0;

    [SerializeField] private GameObject shopItemPrefab = null;
    [SerializeField] private ChildSceneUIHandler childSceneUIHandler = null;

    private Button hatSelectedButton;
    private Button jacketSelectedButton;
    private Button accesorySelectedButton;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            SwitchCategory();
        }
    }

    private void SwitchCategory()
    {

        foreach (GameObject item in currentShopObjects)
        {
            Destroy(item);
        }

        if(categoryIndex+1 != categoryLists.Count)
        categoryIndex++;
        else
            categoryIndex = 0;

        currentList = categoryLists[categoryIndex];

        foreach (ItemInfo item in currentList)
        {
            GameObject newShopItem = Instantiate(shopItemPrefab);
            newShopItem.GetComponentsInChildren<Image>()[1].sprite = item.shopSprite;
            newShopItem.GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item); });
            newShopItem.GetComponentInChildren<Text>().text = item.price.ToString();
            newShopItem.transform.SetParent(transform, false);
            currentShopObjects.Add(newShopItem);
        }
    }

    private void Start()
    {
        categoryLists.Add(hatList);
        categoryLists.Add(jacketList);
        categoryLists.Add(accesoryList);
        categoryLists.Add(foodList);
        currentList = categoryLists[categoryIndex];

        foreach (ItemInfo item in currentList)
        {
            GameObject newShopItem = Instantiate(shopItemPrefab);
            newShopItem.GetComponentsInChildren<Image>()[1].sprite = item.shopSprite;
            newShopItem.GetComponent<Button>().onClick.AddListener(delegate { BuyItem(item); });
            newShopItem.GetComponentInChildren<Text>().text = item.price.ToString();
            newShopItem.transform.SetParent(transform, false);
            currentShopObjects.Add(newShopItem);
        }
    }

    private void BuyItem(ItemInfo item)
    {
        if(item.category!= ItemInfo.categories.food)
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
        else
        {
            if(UserManager.Instance.getGold >= item.price && UserManager.Instance.getHunger < 1)
            {
                UserManager.Instance.setGold(-item.price);
                UserManager.Instance.setHunger(0.3f);
            }
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

        if (accesorySelectedButton != null && item.category == ItemInfo.categories.accesory)
            accesorySelectedButton.GetComponent<Outline>().effectColor = Color.green;

        if (item.category == ItemInfo.categories.accesory)
            accesorySelectedButton = button;

        childSceneUIHandler.SetCustomization(item);
        button.GetComponent<Outline>().effectColor = Color.blue;
    }
}
