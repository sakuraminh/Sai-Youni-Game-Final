using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPrefabAbs : PetAbs
{
    [SerializeField] protected PetPrefabCtrl petPrefabCtrl;
    public PetPrefabCtrl PetPrefabCtrl => this.petPrefabCtrl;


    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPetPrefabCtrl();

    }
    protected virtual void LoadPetPrefabCtrl()
    {
        if (this.petPrefabCtrl != null) return;
        this.petPrefabCtrl = transform.parent.GetComponent<PetPrefabCtrl>();
        Debug.Log(transform.name + ": LoadPetPrefabCtrl", gameObject);
    }
    #endregion
}
