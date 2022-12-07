using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<ItemInfo> currentList = new List<ItemInfo>();
    private List<GameObject> currentShopObjects = new List<GameObject>();
    private List<ItemInfo> boughtList = new List<ItemInfo>();
    private List<ItemInfo> selectedList = new List<ItemInfo>();

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
            if (item.price >= UserManager.Instance.getGold)
                newShopItem.GetComponent<Button>().interactable = false;
            if (boughtList.Contains(item))
            {
                newShopItem.GetComponent<Button>().interactable = true;
                if (selectedList.Contains(item))
                {
                    if (item.category == ItemInfo.categories.hats)
                        hatSelectedButton = newShopItem.GetComponent<Button>();
                    if (item.category == ItemInfo.categories.jackets)
                        jacketSelectedButton = newShopItem.GetComponent<Button>();
                    if (item.category == ItemInfo.categories.accesory)
                        accesorySelectedButton = newShopItem.GetComponent<Button>();

                    newShopItem.GetComponent<Outline>().effectColor = Color.blue;
                }
                else
                {
                    newShopItem.GetComponent<Outline>().effectColor = Color.green;
                    newShopItem.GetComponent<Button>().onClick.AddListener(delegate { EquipItem(item); });
                }
            }


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

            if (item.price >= UserManager.Instance.getGold)
                newShopItem.GetComponent<Button>().interactable = false;
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
                boughtList.Add(item);
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
        {
            foreach (ItemInfo obj in selectedList.ToArray())
            {
                if(obj.category == ItemInfo.categories.hats)
                    selectedList.Remove(obj);
            }
            hatSelectedButton.GetComponent<Outline>().effectColor = Color.green;
        }


        if (item.category == ItemInfo.categories.hats)
        {
            selectedList.Add(item);
            hatSelectedButton = button;
        }

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
