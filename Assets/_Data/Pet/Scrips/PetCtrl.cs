using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCtrl : MMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => this.playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();

    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

}
