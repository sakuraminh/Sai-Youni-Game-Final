using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetCtrl : MMonoBehaviour
{
    [SerializeField] protected GameCtrl gameCtrl;
    public GameCtrl GameCtrl => this.gameCtrl;

    [SerializeField] protected PetRadarAttack petRadarAttack;
    public PetRadarAttack PetRadarAttack => this.petRadarAttack;







    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameCtrl();
        this.LoadPetRadarAttack();

    }

    protected virtual void LoadPetRadarAttack()
    {
        if (this.petRadarAttack != null) return;
        this.petRadarAttack = GameObject.Find("PetRadarAttack").GetComponent<PetRadarAttack>();
        Debug.Log(transform.name + ": LoadPetRadarAttack", gameObject);
    }

    protected virtual void LoadGameCtrl()
    {
        if (this.gameCtrl != null) return;
        this.gameCtrl = GameObject.Find("GameCtrl").GetComponent<GameCtrl>();
        Debug.Log(transform.name + ": LoadGameCtrl", gameObject);
    }
}
