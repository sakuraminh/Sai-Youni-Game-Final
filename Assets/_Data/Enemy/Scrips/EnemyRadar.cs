using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MMonoBehaviour
{
    [SerializeField] protected PlayerCheck playerNearest;
    public PlayerCheck PlayerNearest => this.playerNearest;

    [SerializeField] protected Collider _collider;
    [SerializeField] protected List<PlayerCheck> playerChecks = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void Update()
    {
        this.FindPlayerByDistance();
    }

    protected virtual void FindPlayerByDistance()
    {
        if (playerChecks.Count == 0)
        {
            this.playerNearest = null;
            return;
        }

        float distanceNearest = Mathf.Infinity;
        float distancePlayer = 0;

        foreach (PlayerCheck playerCheck in playerChecks)
        {
            distancePlayer = Vector3.Distance(transform.parent.position, playerCheck.transform.parent.position);
            if (distancePlayer < distanceNearest)
            {
                distanceNearest = distancePlayer;
                this.playerNearest = playerCheck;
            }
        }
    }

    private void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<Collider>();
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        PlayerCheck playerCheck = collider.GetComponent<PlayerCheck>();
        if (playerCheck == null) return;
        playerChecks.Add(playerCheck);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (playerChecks.Count == 0) return;
        PlayerCheck playerCheck = collider.GetComponent<PlayerCheck>();
        if (playerCheck == null) return;
        playerChecks.Remove(playerCheck);
    }
}
