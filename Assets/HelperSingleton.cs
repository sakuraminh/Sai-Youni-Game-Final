using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperSingleton : MSingleton<HelperSingleton>
{
    [SerializeField] protected RandomPointOnNavMesh randomPointOnNavMesh;
    public RandomPointOnNavMesh RandomPointOnNavMesh => this.randomPointOnNavMesh;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRandomPointOnNavMesh();
    }
    protected virtual void LoadRandomPointOnNavMesh()
    {
        if (this.randomPointOnNavMesh != null) return;
        this.randomPointOnNavMesh = GetComponentInChildren<RandomPointOnNavMesh>();
        Debug.Log(transform.name + ": LoadRandomPointOnNavMesh", gameObject);
    }
}
