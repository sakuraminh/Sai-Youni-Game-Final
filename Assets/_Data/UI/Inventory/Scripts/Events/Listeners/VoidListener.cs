using System.Linq.Expressions;
using UnityEngine;

public class VoidListener : BaseGameEventListener<Void, VoidEvent, UnityVoidEvent>
{

    protected override void LoadgameEvent()
    {
        base.LoadgameEvent();
        if (this.GameEvent != null) return;
        this.GameEvent = Resources.Load<VoidEvent>("GameEvents/Inventory/GameEvent_Inventory_OnInventoryItemsUpdated");
        Debug.Log("GameEvent Loaded: " + this.GameEvent.name, gameObject);
    }
}

