
using UnityEngine;
using UnityEngine.AI;

public class PetMoving : PetAbs
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected PetAttack petAttack;
    public PetAttack PetAttack => this.petAttack;

    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 3f;

    [SerializeField] protected float range = 3f;
    [SerializeField] protected float validRange = 1f;

    [SerializeField] protected bool isMoving = false;
    public bool IsMoving => this.isMoving = true;

    void Update()
    {
        this.RandomMoving();
    }

    public void SetMoving(bool isMoving)
    {
        this.isMoving = isMoving;
    }

    protected virtual void RandomMoving()
    {
        if (NavMesh.SamplePosition(this.petCtrl.GameCtrl.PlayerCtrl.transform.position, out NavMeshHit hit, validRange, NavMesh.AllAreas))
        {
            if (this.petCtrl.GameCtrl.PlayerCtrl.PlayerMoving.IsMoving)
            {
                agent.SetDestination(hit.position);
                this.isMoving = true;
                return;
            }
        }

        if (agent.remainingDistance <= agent.stoppingDistance + 1)
        {
            this.timer += Time.deltaTime;
            if (this.timer >= this.delay) this.timer = this.delay;
            if (this.timer < this.delay) return;


            if (petCtrl.GameCtrl.Helper.RandomPointOnNavMesh.RandomPoint(this.petCtrl.GameCtrl.PlayerCtrl.transform.position, range, validRange, out Vector3 point))
            {
                this.timer = 0;
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            }
            agent.SetDestination(point);
            this.isMoving = true;
            return;
        }
        this.isMoving = false;
    }
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadPetAttack();
        this.SetAgent();
    }
    protected virtual void SetAgent()
    {
        agent.acceleration = float.MaxValue;
        agent.autoBraking = false;
        agent.stoppingDistance = 0;
        agent.angularSpeed = float.MaxValue;
        agent.speed = 8;
    }
    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponentInParent<NavMeshAgent>();
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }
    protected virtual void LoadPetAttack()
    {
        if (this.petAttack != null) return;
        this.petAttack = transform.parent.GetComponentInChildren<PetAttack>();
        Debug.Log(transform.name + ": LoadPetAttack", gameObject);
    }
    #endregion
}
