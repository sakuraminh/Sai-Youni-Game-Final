using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : EnemyAbs
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected EnemyRadar enemyRadar;

    public Vector3 spawnArea;

    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 3f;
    [SerializeField] protected float range = 15f;

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

            if (enemyRadar.PlayerNearest != null) point = enemyRadar.PlayerNearest.transform.position;

            else if (RandomPoint(spawnArea, range, out point))
            {
                this.timer = 0;
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            }

            agent.SetDestination(point);
        }
    }
    protected virtual bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
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
