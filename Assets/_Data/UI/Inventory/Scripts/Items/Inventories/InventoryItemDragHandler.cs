using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemDragHandler : ItemDragHandler
{

    [SerializeField] private ItemDestroyer itemDestroyer;

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            base.OnPointerUp(eventData);

            if (eventData.hovered.Count == 0)
            {
                InventorySlot thisSlot = this.itemSlotUI as InventorySlot;
                itemDestroyer.Activate(thisSlot.ItemSlot, thisSlot.SlotIndex);
            }
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDestroyer();
    }

    protected virtual void LoadItemDestroyer()
    {
        if (this.itemDestroyer != null) return;
        //this.itemDestroyer = transform.parent.parent.parent.parent.parent.GetComponentInChildren<ItemDestroyer>();
        this.itemDestroyer = transform.root.GetComponentInChildren<ItemDestroyer>();
        Debug.Log(transform.name + ": LoadItemDestroyer", gameObject);
    }
}

