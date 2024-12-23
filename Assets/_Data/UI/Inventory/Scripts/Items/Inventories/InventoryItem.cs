﻿using UnityEngine;

public abstract class InventoryItem : HotbarItem
{
    [Header("Item Data")]
    [SerializeField] private Rarity rarity = null;
    [SerializeField][Min(0)] private int sellPrice = 1;
    [SerializeField][Min(1)] private int maxStack = 1;
    [SerializeField] protected float value = 0f;

    public override string ColouredName
    {
        get
        {
            string hexColour = ColorUtility.ToHtmlStringRGB(rarity.TextColour);
            return $"<color=#{hexColour}>{name}</color>";
        }
    }
    public int SellPrice => sellPrice;
    public int MaxStack => maxStack;
    public Rarity Rarity => rarity;
    //public override void Use(GameObject user)
    //{
    //    //
    //}
}

