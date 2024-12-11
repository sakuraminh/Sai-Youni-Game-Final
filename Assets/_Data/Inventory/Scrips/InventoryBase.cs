using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBase : MMonoBehaviour
{
    [SerializeField] protected VoidEvent onInventoryItemsUpdated;
    [SerializeField] protected ItemSlot testItemSlot = new ItemSlot();

    public ItemContainer ItemContainer { get; } = new ItemContainer(100);

    protected override void OnEnable() => ItemContainer.OnItemsUpdated += onInventoryItemsUpdated.Raise;

    protected override void OnDisable() => ItemContainer.OnItemsUpdated -= onInventoryItemsUpdated.Raise;

    [ContextMenu("Test Add")]

    public void TestAdd()
    {
        ItemContainer.AddItem(testItemSlot);
    }

    public virtual void AddItem(InventoryItem item, int quatity)
    {
        ItemContainer.AddItem(new ItemSlot(item, quatity));
    }

    public virtual void RemoveItem(InventoryItem item, int quatity, int index)
    {
        ItemContainer.RemoveItemAt(new ItemSlot(item, quatity), index);
    }
}


