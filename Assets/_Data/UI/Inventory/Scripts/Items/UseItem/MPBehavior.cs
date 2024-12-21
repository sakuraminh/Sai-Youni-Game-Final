using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MP Behavior", menuName = "Items/ItemBehavior/MP Behavior")]
public class MPBehavior : IItemBehavior
{
    public override void Execute(GameObject user, float value)
    {
        PlayerCtrl playerCtrl = user.transform.GetComponent<PlayerCtrl>();
        if (playerCtrl != null)
        {
            playerCtrl.PlayerAttack.RestoreMana(value);
        }
    }
}
