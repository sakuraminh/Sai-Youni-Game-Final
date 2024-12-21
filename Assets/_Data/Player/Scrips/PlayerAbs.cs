using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbs : MMonoBehaviour
{
    [Header("PlayerAbs")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    private void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.root.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    #endregion
}
