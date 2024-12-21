using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MMonoBehaviour
{
    [SerializeField] protected GameCtrl gameCtrl;
    public GameCtrl GameCtrl => gameCtrl;

    [SerializeField] protected ItemDestroyer itemDestroyer;
    public ItemDestroyer ItemDestroyer => itemDestroyer;

    [SerializeField] protected PlayerHPUI playerHPUI;
    public PlayerHPUI PlayerHPUI => playerHPUI;

    [SerializeField] protected ReloadSince reloadSince;
    public ReloadSince ReloadSince => reloadSince;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameCtrl();
        this.LoadItemDestroyer();
        this.LoadPlayerHPUI();
        this.LoadReloadSince();
    }

    protected virtual void LoadReloadSince()
    {
        if (this.reloadSince != null) return;
        this.reloadSince = GetComponentInChildren<ReloadSince>();
        Debug.Log(transform.name + ": LoadReloadSince", gameObject);
    }

    protected virtual void LoadPlayerHPUI()
    {
        if (this.playerHPUI != null) return;
        this.playerHPUI = GetComponentInChildren<PlayerHPUI>();
        Debug.Log(transform.name + ": LoadPlayerHPUI", gameObject);
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
