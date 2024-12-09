using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PetAbs : MMonoBehaviour
{
    [SerializeField] protected PetCtrl petCtrl;
    public PetCtrl PetCtrl => this.petCtrl;
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPetCtrl();

    }
    protected virtual void LoadPetCtrl()
    {
        if (this.petCtrl != null) return;
        this.petCtrl = transform.root.GetComponent<PetCtrl>();
        Debug.Log(transform.name + ": LoadPetCtrl", gameObject);
    }
    #endregion
}
