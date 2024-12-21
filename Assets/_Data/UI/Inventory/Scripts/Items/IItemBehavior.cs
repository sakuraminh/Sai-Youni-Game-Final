using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IItemBehavior : ScriptableObject
{
    public abstract void Execute(GameObject user, float value);
}
