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

    public void SwitchCategory(int amount)
    {
        foreach (GameObject item in currentShopObjects)
        {
            Destroy(item);
        }

        if (categoryIndex + amount > categoryLists.Count-1)
            categoryIndex = 0;
        else if (categoryIndex + amount < 0)
            categoryIndex = categoryLists.Count-1;
        else
            categoryIndex += amount;
        currentList = categoryLists[categoryIndex];

        foreach (ItemInfo item in currentList)
        {
            childSceneUIHandler.UpdateCategory(item.category);
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
                    if (item.category == ItemInfo.categories.Hats)
                        hatSelectedButton = newShopItem.GetComponent<Button>();
                    if (item.category == ItemInfo.categories.Jackets)
                        jacketSelectedButton = newShopItem.GetComponent<Button>();
                    if (item.category == ItemInfo.categories.Accesory)
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
        if(item.category!= ItemInfo.categories.Food)
        {
            Button button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            if (UserManager.Instance.getGold >= item.price &&
                button.GetComponent<Outline>().effectColor == new Color(0.7568628f, 0.9411765f, 0.9686275f, 1))
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

        if (hatSelectedButton != null && item.category == ItemInfo.categories.Hats)
        {
            
            hatSelectedButton.GetComponent<Outline>().effectColor = Color.green;
            foreach (ItemInfo obj in selectedList.ToArray())
            {
                if (obj.category == ItemInfo.categories.Hats)
                    hatSelectedButton.onClick.AddListener(delegate { EquipItem(obj); });
            }
            foreach (ItemInfo obj in selectedList.ToArray())
            {
                if (obj.category == ItemInfo.categories.Hats)
                    selectedList.Remove(obj);
            }
        }

        if (item.category == ItemInfo.categories.Hats)
        {
            selectedList.Add(item);
            hatSelectedButton = button;
        }

        if (jacketSelectedButton != null && item.category == ItemInfo.categories.Jackets)
        {

            jacketSelectedButton.GetComponent<Outline>().effectColor = Color.green;
            foreach (ItemInfo obj in selectedList.ToArray())
            {
                if (obj.category == ItemInfo.categories.Jackets)
                    jacketSelectedButton.onClick.AddListener(delegate { EquipItem(obj); });
            }
            foreach (ItemInfo obj in selectedList.ToArray())
            {
                if (obj.category == ItemInfo.categories.Jackets)
                    selectedList.Remove(obj);
            }
        }

        if (item.category == ItemInfo.categories.Jackets)
        {
            selectedList.Add(item);
            jacketSelectedButton = button;
        }

        if (accesorySelectedButton != null && item.category == ItemInfo.categories.Accesory)
        {

            accesorySelectedButton.GetComponent<Outline>().effectColor = Color.green;
            foreach (ItemInfo obj in selectedList.ToArray())
            {
                if (obj.category == ItemInfo.categories.Accesory)
                    accesorySelectedButton.onClick.AddListener(delegate { EquipItem(obj); });
            }
            foreach (ItemInfo obj in selectedList.ToArray())
            {
                if (obj.category == ItemInfo.categories.Accesory)
                    selectedList.Remove(obj);
            }
        }

        if (item.category == ItemInfo.categories.Accesory)
        {
            selectedList.Add(item);
            accesorySelectedButton = button;
        }


        childSceneUIHandler.SetCustomization(item);
        button.GetComponent<Outline>().effectColor = Color.blue;
    }
}
