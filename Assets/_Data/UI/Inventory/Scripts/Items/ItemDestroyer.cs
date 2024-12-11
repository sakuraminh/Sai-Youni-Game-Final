using TMPro;
using UnityEngine;

public class ItemDestroyer : MMonoBehaviour
{
    [SerializeField] protected GameObject itemDestroyer;
    [SerializeField] protected InventoryItems inventory;
    //[SerializeField] private Inventory inventory = null;
    [SerializeField] private TextMeshProUGUI areYouSureText = null;

    [SerializeField] private int slotIndex;

    protected override void OnDisable() => slotIndex = -1;

    public void Activate(ItemSlot itemSlot, int slotIndex)
    {
        this.slotIndex = slotIndex;

        areYouSureText.text = $"Are you sure you wish to destroy {itemSlot.quantity}x {itemSlot.item.ColouredName}?";

        itemDestroyer.SetActive(true);
    }

    public void Destroy()
    {
        inventory.ItemContainer.RemoveAt(slotIndex);

        itemDestroyer.SetActive(false);
    }

    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDestroyer();
    }

    protected virtual void LoadItemDestroyer()
    {
        if (this.itemDestroyer != null) return;
        this.itemDestroyer = transform.Find("Canvas_DestroyItem").gameObject;
        Debug.Log(transform.name + ": LoadItemDestroyer", gameObject);
    }

}

