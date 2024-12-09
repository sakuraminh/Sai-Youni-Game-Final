using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCurrency : InventoryBase
{
    public new ItemContainer ItemContainer { get; } = new ItemContainer(45);
}
