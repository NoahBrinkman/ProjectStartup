using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoney : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Text>().text = UserManager.Instance.getGold.ToString();
    }
}
