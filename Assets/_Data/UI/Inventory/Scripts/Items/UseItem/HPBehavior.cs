using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New HP Behavior", menuName = "Items/ItemBehavior/HP Behavior")]
public class HPBehavior : IItemBehavior
{
    public override void Execute(GameObject user, float value)
    {
        PlayerCtrl playerCtrl = user.transform.GetComponent<PlayerCtrl>();
        if (playerCtrl != null)
        {
            playerCtrl.PlayerDameReceive.Heal(value);
        }
    }
}

