using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : EnemyAbs
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected EnemyRadar enemyRadar;

    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 3f;

    [SerializeField] protected Vector3 spawnAreaPos;
    [SerializeField] protected float range = 15f;
    [SerializeField] protected float validRange = 1f;

    void Update()
    {
        this.RandomMoving();
    }
    protected virtual void RandomMoving()
    {
        this.timer += Time.deltaTime;
        if (this.timer >= this.delay) this.timer = this.delay;
        if (this.timer < this.delay) return;

        Vector3 point;

        if (agent.remainingDistance <= agent.stoppingDistance)
        {

            if (enemyRadar.TargetNearest != null)
            {
                if (NavMesh.SamplePosition(enemyRadar.TargetNearest.transform.position, out NavMeshHit hit, this.validRange, NavMesh.AllAreas))
                {
                    point = hit.position;
                    agent.SetDestination(point);
                    return;
                }
                point = this.spawnAreaPos;
                agent.SetDestination(point);
                return;

            }

            else if (EnemyCtrl.Helper.RandomPointOnNavMesh.RandomPoint(spawnAreaPos, range, validRange, out point))
            {
                this.timer = 0;
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }


        }
    }
    public virtual void SetSpawnAreaPos(Vector3 pos)
    {
        this.spawnAreaPos = pos;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadEnemyRadar();
    }
    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponentInParent<NavMeshAgent>();
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

    protected virtual void LoadEnemyRadar()
    {
        if (this.enemyRadar != null) return;
        this.enemyRadar = transform.parent.GetComponentInChildren<EnemyRadar>();
        Debug.Log(transform.name + ": LoadEnemyRadar", gameObject);
    }
}
