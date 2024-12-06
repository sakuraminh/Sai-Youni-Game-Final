using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PetAbs : MMonoBehaviour
{
    [SerializeField] protected PetCtrl petCtrl;
    public PetCtrl PetCtrl => this.petCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPetCtrl();

    }
    protected virtual void LoadPetCtrl()
    {
        if (this.petCtrl != null) return;
        this.petCtrl = GetComponentInParent<PetCtrl>();
        Debug.Log(transform.name + ": LoadPetCtrl", gameObject);
    }
}
