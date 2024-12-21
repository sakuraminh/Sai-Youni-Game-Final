using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetPrefabCtrl : MMonoBehaviour
{
    [SerializeField] protected PetMoving petMoving;
    public PetMoving PetMoving => petMoving;

    [SerializeField] protected PetAttack petAttack;
    public PetAttack PetAttack => petAttack;

    [SerializeField] protected PetRadarAttack petRadarAttack;
    public PetRadarAttack PetRadarAttack => petRadarAttack;

    [SerializeField] protected NavMeshAgent navMeshAgent;
    public NavMeshAgent NavMeshAgent => this.navMeshAgent;

    [SerializeField] protected Animator animator;
    public Animator Animator => this.animator;

    [SerializeField] protected PetSenDamePoint petSenDamePoint;
    public PetSenDamePoint PetSenDamePoint => this.petSenDamePoint;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPetMoving();
        this.LoadPetAttack();
        this.LoadPetRadarAttack();
        this.LoadNavMeshAgent();
        this.LoadAnimator();
        this.LoadPetSenDamePoint();
    }
    protected virtual void LoadPetSenDamePoint()
    {
        if (this.petSenDamePoint != null) return;
        this.petSenDamePoint = GetComponentInChildren<PetSenDamePoint>();
        Debug.Log(transform.name + ": LoadPetSenDamePoint", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadNavMeshAgent()
    {
        if (this.navMeshAgent != null) return;
        this.navMeshAgent = GetComponent<NavMeshAgent>();
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

    protected virtual void LoadPetMoving()
    {
        if (this.petMoving != null) return;
        this.petMoving = GetComponentInChildren<PetMoving>();
        Debug.Log(transform.name + ": LoadPetMoving", gameObject);
    }

    protected virtual void LoadPetAttack()
    {
        if (this.petAttack != null) return;
        this.petAttack = GetComponentInChildren<PetAttack>();
        Debug.Log(transform.name + ": LoadPetAttack", gameObject);
    }

    protected virtual void LoadPetRadarAttack()
    {
        if (this.petRadarAttack != null) return;
        this.petRadarAttack = GetComponentInChildren<PetRadarAttack>();
        Debug.Log(transform.name + ": LoadPetRadarAttack", gameObject);
    }
}
