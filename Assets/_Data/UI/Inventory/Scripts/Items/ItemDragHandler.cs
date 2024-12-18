
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class ItemDragHandler : MMonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] protected UICtrl uICtrl;

    [SerializeField] protected HotbarItemEvent onMouseStartHoverItem;
    [SerializeField] protected VoidEvent onMouseEndHoverItem;

    [SerializeField] protected ItemSlotUI itemSlotUI;
    public ItemSlotUI ItemSlotUI => this.itemSlotUI;

    private CanvasGroup canvasGroup = null;
    private Transform originalParent = null;

    protected bool isHovering = false;



    protected override void Start() => canvasGroup = GetComponent<CanvasGroup>();

    protected override void OnDisable()
    {
        if (isHovering)
        {
            onMouseEndHoverItem.Raise();
            isHovering = false;
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            onMouseEndHoverItem.Raise();

            originalParent = transform.parent;

            transform.SetParent(transform.parent.parent.parent.parent);

            canvasGroup.blocksRaycasts = false;
        }
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = Input.mousePosition;
        }
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onMouseStartHoverItem.Raise(ItemSlotUI.SlotItem);
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onMouseEndHoverItem.Raise();
        isHovering = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            InventoryItem item = ItemSlotUI.SlotItem as InventoryItem;
            InventorySlot inventorySlot = ItemSlotUI as InventorySlot;
            uICtrl.GameCtrl.InventoryCtrl.InventoryItems.UseItem(item, 1, inventorySlot.SlotIndex);
            //Debug.Log("Right Click");
        }
    }




    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSlotUI();
        this.LoadOnMouseStartHoverItem();
        this.LoadOnMouseEndHoverItem();
        this.LoadUICtrl();
    }

    protected virtual void LoadUICtrl()
    {
        if (this.uICtrl != null) return;
        this.uICtrl = transform.root.GetComponent<UICtrl>();
        Debug.Log(transform.name + ": LoadUICtrl", gameObject);
    }

    protected virtual void LoadOnMouseEndHoverItem()
    {
        if (this.onMouseEndHoverItem != null) return;
        this.onMouseEndHoverItem = Resources.Load<VoidEvent>("GameEvents/Inventory/GameEvent_Inventory_OnMouseEndHoverItem");
        Debug.Log(transform.name + ": LoadOnMouseEndHoverItem", gameObject);
    }
    protected virtual void LoadOnMouseStartHoverItem()
    {
        if (this.onMouseStartHoverItem != null) return;
        this.onMouseStartHoverItem = Resources.Load<HotbarItemEvent>("GameEvents/Inventory/GameEvent_Inventory_OnMouseStartHoverItem");
        Debug.Log(transform.name + ": LoadOnMouseStartHoverItem", gameObject);
    }
    protected virtual void LoadItemSlotUI()
    {
        if (this.itemSlotUI != null) return;
        this.itemSlotUI = transform.parent.GetComponent<ItemSlotUI>();
        Debug.Log(transform.name + ": LoadItemSlotUI", gameObject);
    }

    #endregion
}

