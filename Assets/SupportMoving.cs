using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SupportMoving : MMonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected PlayerCtrl playerCtrl;

    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 3f;

    [SerializeField] protected float range = 5f;
    [SerializeField] protected float validRange = 1f;


    void Update()
    {
        this.RandomMoving();
    }
    protected virtual void RandomMoving()
    {
        Vector3 point;

        if (this.playerCtrl.PlayerMoving.IsMoving())
        {
            point = this.playerCtrl.transform.position;
            agent.SetDestination(point);
            return;
        }

        this.timer += Time.deltaTime;
        if (this.timer >= this.delay) this.timer = this.delay;
        if (this.timer < this.delay) return;

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (HelperSingleton.Instance.RandomPointOnNavMesh.RandomPoint(this.playerCtrl.transform.position, range, validRange, out point))
            {
                this.timer = 0;
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            }
            agent.SetDestination(point);
        }
    }
    //protected virtual float DistanceToPlayer()
    //{
    //    return Vector3.Distance(Vector3.Scale(this.transform.position, new Vector3(1, 0, 1)), Vector3.Scale(this.playerCtrl.transform.position, new Vector3(1, 0, 1)));
    //}
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponentInParent<NavMeshAgent>();
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
