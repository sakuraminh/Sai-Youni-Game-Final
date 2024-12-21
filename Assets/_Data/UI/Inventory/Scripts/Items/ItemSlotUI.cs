using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemSlotUI : MMonoBehaviour, IDropHandler
{
    [SerializeField] protected Image itemIconImage;
    [SerializeField] protected TextMeshProUGUI itemQuantityText;
    [SerializeField] protected InventoryBase inventory;

    public int SlotIndex { get; private set; }

    public abstract HotbarItem SlotItem { get; set; }

    protected override void OnEnable() => UpdateSlotUI();

    protected override void Start()
    {
        SlotIndex = transform.GetSiblingIndex();
        UpdateSlotUI();
    }

    public abstract void OnDrop(PointerEventData eventData);

    public abstract void UpdateSlotUI();

    protected virtual void EnableSlotUI(bool enable) => itemIconImage.enabled = enable;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemIconImage();
        this.LoadItemQuantityText();
    }
    protected virtual void LoadItemQuantityText()
    {
        if (this.itemQuantityText != null) return;
        this.itemQuantityText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadItemQuantityText", gameObject);
    }
    protected virtual void LoadItemIconImage()
    {
        if (this.itemIconImage != null) return;
        this.itemIconImage = GetComponentInChildren<ItemDragHandler>().transform.GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemIconImage", gameObject);
    }

}


