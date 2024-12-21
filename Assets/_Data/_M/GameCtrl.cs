using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => this.playerCtrl;

    [SerializeField] protected Helper helper;
    public Helper Helper => this.helper;

    [SerializeField] protected EffectCtrl effectCtrl;
    public EffectCtrl EffectCtrl => this.effectCtrl;

    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => this.enemyCtrl;

    [SerializeField] protected ItemCrl itemCrl;
    public ItemCrl ItemCrl => this.itemCrl;

    [SerializeField] protected InventoryCtrl inventoryCtrl;
    public InventoryCtrl InventoryCtrl => this.inventoryCtrl;

    [SerializeField] protected PetCtrl petCtrl;
    public PetCtrl PetCtrl => this.petCtrl;

    [SerializeField] protected UICtrl uicCtrl;
    public UICtrl UICtrl => this.uicCtrl;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadHelper();
        this.LoadEffectCtrl();
        this.LoadEnemyCtrl();
        this.LoadItemCrl();
        this.LoadInventoryCtrl();
        this.LoadPetCtrl();
        this.LoadUICtrl();
    }

    protected virtual void LoadUICtrl()
    {
        if (this.uicCtrl != null) return;
        this.uicCtrl = GameObject.Find("UI").GetComponent<UICtrl>();
        Debug.Log(transform.name + ": LoadUICtrl", gameObject);
    }

    protected virtual void LoadPetCtrl()
    {
        if (this.petCtrl != null) return;
        this.petCtrl = GameObject.Find("Pet").GetComponent<PetCtrl>();
        Debug.Log(transform.name + ": LoadPetCtrl", gameObject);
    }

    protected virtual void LoadInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = GameObject.Find("Inventory").GetComponent<InventoryCtrl>();
        Debug.Log(transform.name + ": LoadInventoryCtrl", gameObject);
    }

    protected virtual void LoadItemCrl()
    {
        if (this.itemCrl != null) return;
        this.itemCrl = GameObject.Find("Item").GetComponent<ItemCrl>();
        Debug.Log(transform.name + ": LoadItemCrl", gameObject);
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GameObject.Find("Enemy").GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected virtual void LoadEffectCtrl()
    {
        if (this.effectCtrl != null) return;
        this.effectCtrl = GameObject.Find("Effect").GetComponent<EffectCtrl>();
        Debug.Log(transform.name + ": LoadEffectCtrl", gameObject);
    }

    protected virtual void LoadHelper()
    {
        if (this.helper != null) return;
        this.helper = GameObject.Find("Helper").GetComponent<Helper>();
        Debug.Log(transform.name + ": LoadHelper", gameObject);
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
