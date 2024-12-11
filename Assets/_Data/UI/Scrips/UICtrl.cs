using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MMonoBehaviour
{
    [SerializeField] protected GameCtrl gameCtrl;
    public GameCtrl GameCtrl => gameCtrl;

    [SerializeField] protected ItemDestroyer itemDestroyer;
    public ItemDestroyer ItemDestroyer => itemDestroyer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameCtrl();
        this.LoadItemDestroyer();
    }


    protected virtual void LoadItemDestroyer()
    {
        if (this.itemDestroyer != null) return;
        this.itemDestroyer = GetComponentInChildren<ItemDestroyer>();
        Debug.Log(transform.name + ": LoadItemDestroyer", gameObject);
    }
    protected virtual void LoadGameCtrl()
    {
        if (this.gameCtrl != null) return;
        this.gameCtrl = GameObject.Find("GameCtrl").GetComponent<GameCtrl>();
        Debug.Log(transform.name + ": LoadGameCtrl", gameObject);
    }
}
