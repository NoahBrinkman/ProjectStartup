using UnityEngine;

[System.Serializable]
public struct ItemInfo
{
    public string identifier;
    public int price;
    public Sprite visuals;
    public enum categories {hats, backgrounds, jackets, food};
    public categories category;
}