using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : EnemyPrefabAbs
{
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => this.agent;
    [SerializeField] protected EnemyRadar enemyRadar;

    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 3f;

    [SerializeField] protected float range = 15f;
    [SerializeField] protected float validRange = 1f;

    [SerializeField] protected Vector3 spawnAreaPos;
    [SerializeField] protected bool isMoving = true;
    public bool IsMoving => this.isMoving;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.SetMoving(true);
        this.agent.speed = 0.5f;
        this.agent.SetDestination(this.spawnAreaPos);
    }

    void Update()
    {
        this.RandomMoving();
    }
    protected virtual void RandomMoving()
    {
        this.timer += Time.deltaTime;
        if (this.timer >= this.delay) this.timer = this.delay;
        if (this.timer < this.delay) return;

        if (this.isMoving == true)
        {
            this.agent.isStopped = false;
            if (enemyRadar.TargetNearest != null)
            {
                if (NavMesh.SamplePosition(enemyRadar.TargetNearest.transform.position, out NavMeshHit hit, this.validRange, NavMesh.AllAreas))
                {
                    this.agent.speed = 5f;
                    agent.SetDestination(hit.position);
                    return;
                }
                agent.SetDestination(this.spawnAreaPos);
                return;
            }
            else if (EnemyCtrl.GameCtrl.Helper.RandomPointOnNavMesh.RandomPoint(spawnAreaPos, range, validRange, out Vector3 point))
            {
                this.agent.speed = 0.5f;

                this.timer = 0;
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
        else if (this.isMoving == false) this.agent.isStopped = true;
    }

    public virtual void SetMoving(bool isMoving)
    {
        this.isMoving = isMoving;
    }
    public virtual void SetSpawnAreaPos(Vector3 pos)
    {
        this.spawnAreaPos = pos;
    }
    #region LoadComponents
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
    #endregion
}
