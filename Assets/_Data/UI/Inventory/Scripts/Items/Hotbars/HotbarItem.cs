﻿using UnityEngine;
public abstract class HotbarItem : ScriptableObject
{
    [Header("Basic Info")]
    [SerializeField] protected new string name = "New Hotbar Item Name";
    [SerializeField] private Sprite icon = null;

    public string Name => name;
    public Sprite Icon => icon;
    public abstract string ColouredName { get; }

    public abstract string GetInfoDisplayText();
}

