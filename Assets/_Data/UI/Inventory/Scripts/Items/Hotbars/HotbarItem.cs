using UnityEngine;
public abstract class HotbarItem : ScriptableObject
{
    [Header("Basic Info")]
    [SerializeField] protected new string name = "New Hotbar Item Name";
    [SerializeField] protected Sprite icon = null;
    [SerializeField] protected IItemBehavior behavior = null;

    public string Name => name;
    public Sprite Icon => icon;
    public IItemBehavior Behavior => behavior;
    public abstract string ColouredName { get; }

    public abstract string GetInfoDisplayText();

    public abstract void Use(GameObject user);
}

