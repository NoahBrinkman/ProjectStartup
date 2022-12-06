using UnityEngine;

[System.Serializable]
public struct ItemInfo
{
    public string identifier;
    public float price;
    public Sprite shopSprite;
    public Sprite visuals;
    public enum categories {hats, jackets, accesory, food};
    public categories category;
}