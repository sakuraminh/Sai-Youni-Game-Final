using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : ItemSlotUI, IDropHandler
{
    [SerializeField] private Inventory inventory; // được thêm bằng cách kéo thả Inventory vào trường inventory trong Inspector
                                                  //[SerializeField] private TextMeshProUGUI itemQuantityText = null; // được thêm bằng cách kéo thả TextMeshProUGUI vào trường itemQuantityText trong Inspector

    public override HotbarItem SlotItem
    {
        get { return ItemSlot.item; }
        set { }
    }

    // (SlotIndex == index của tranform thuộc parent) đã được khởi tạo trong start của lớp cha
    // ItemSlot chính là ItemSlot tương ứng với SlotIndex trong ItemContainer của Inventory
    public ItemSlot ItemSlot => inventory.ItemContainer.GetSlotByIndex(SlotIndex);

    public override void OnDrop(PointerEventData eventData)
    {
        ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();

        if (itemDragHandler == null) { return; }

        if ((itemDragHandler.ItemSlotUI as InventorySlot) != null)
        {
            inventory.ItemContainer.Swap(itemDragHandler.ItemSlotUI.SlotIndex, SlotIndex);
        }
    }

    // hàm này được override từ lớp cha và được gọi từ lớp cha khi enabled và start
    public override void UpdateSlotUI()
    {
        if (ItemSlot.item == null)
        {
            EnableSlotUI(false);
            return;
        }

        EnableSlotUI(true);

        itemIconImage.sprite = ItemSlot.item.Icon;
        itemQuantityText.text = ItemSlot.quantity > 1 ? ItemSlot.quantity.ToString() : "";
    }

    protected override void EnableSlotUI(bool enable)
    {
        base.EnableSlotUI(enable);
        itemQuantityText.enabled = enable;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = Resources.Load<Inventory>("GameData/Inventory_Player");
        Debug.Log(transform.name + ": LoadInventory", gameObject);
    }
}

