
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PetMoving : PetPrefabAbs
{
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 10f;
    [SerializeField] protected float attackCooldown = 1f, attackTimer;
    [SerializeField] protected Vector3 startPosition;
    [SerializeField] protected Vector3 patrolPointRandom;
    [SerializeField] protected bool isMoving, isAttacking;
    [SerializeField] protected float range = 7, validRange = 5;

    protected enum EnemyState
    {
        Patrolling,
        Chasing,
        Attacking,
        MoveThenAttack
    }
    [SerializeField]
    protected EnemyState currentState;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.CheckPatrolPointRandom();
        this.currentState = EnemyState.Patrolling;
        this.attackTimer = 5f;

    }

    public virtual void SetstartPosition(Vector3 startPosition)
    {
        this.startPosition = startPosition;
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patrol();
                if (this.petCtrl.GameCtrl.PlayerCtrl.PlayerMoving.IsMoving == false)
                {
                    if (this.petCtrl.GameCtrl.PlayerCtrl.PlayerRadar.EnemyInAttackRange() == true)
                    {
                        this.attackTimer = 5f;
                        currentState = EnemyState.MoveThenAttack;
                    }
                }
                else
                {
                    this.attackTimer = 5f;
                    currentState = EnemyState.Chasing;
                }
                break;

            case EnemyState.Chasing:
                ChasePlayer();
                if (this.petCtrl.GameCtrl.PlayerCtrl.PlayerMoving.IsMoving == false)
                {
                    if (this.petCtrl.GameCtrl.PlayerCtrl.PlayerRadar.EnemyInAttackRange() == true)
                    {
                        this.attackTimer = 5f;
                        currentState = EnemyState.MoveThenAttack;
                    }
                    else currentState = EnemyState.Patrolling;
                }
                break;

            case EnemyState.MoveThenAttack:
                MoveThenAttack();
                if (this.petCtrl.GameCtrl.PlayerCtrl.PlayerMoving.IsMoving == false)
                {
                    if (this.petPrefabCtrl.PetRadarAttack.EnemyInAttackRange() == true)
                    {
                        currentState = EnemyState.Attacking;
                    }
                    else if (this.petCtrl.GameCtrl.PlayerCtrl.PlayerRadar.EnemyInAttackRange() == false)
                    {
                        this.attackTimer = 5f;
                        currentState = EnemyState.Patrolling;
                    }
                }
                else currentState = EnemyState.Chasing;

                break;

            case EnemyState.Attacking:
                AttackEnemy();
                if (this.petCtrl.GameCtrl.PlayerCtrl.PlayerMoving.IsMoving == false)
                {
                    if (this.petPrefabCtrl.PetRadarAttack.EnemyInAttackRange() == false)
                    {
                        this.attackTimer = 5f;
                        currentState = EnemyState.MoveThenAttack;
                    }
                }
                else currentState = EnemyState.Chasing;
                break;
        }
    }



    protected virtual void UpdateAnimation(bool isMoving, bool isAttacking)
    {
        this.isMoving = isMoving;
        this.isAttacking = isAttacking;
        this.petPrefabCtrl.Animator.SetBool("isMoving", isMoving);
        this.petPrefabCtrl.Animator.SetBool("isAttacking", isAttacking);
    }

    protected virtual void UpdateSpeet(float speed, float acceleration)
    {
        this.petPrefabCtrl.NavMeshAgent.speed = speed;
        this.petPrefabCtrl.NavMeshAgent.acceleration = acceleration;
    }
    protected virtual void CheckPatrolPointRandom()
    {
        if (isMoving == false)
        {
            this.startPosition = this.petCtrl.GameCtrl.PlayerCtrl.transform.position;

            if (petCtrl.GameCtrl.Helper.RandomPointOnNavMesh.RandomPoint(this.petCtrl.GameCtrl.PlayerCtrl.transform.position, range, validRange, out Vector3 point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                this.patrolPointRandom = point;
                return;
            }
            this.CheckPatrolPointRandom();
        }
    }

    protected virtual void Patrol()
    {
        if (Vector3.Distance(transform.parent.position, patrolPointRandom) < 0.1f)
        {
            this.UpdateAnimation(false, false);
            if (this.timer < this.delay)
            {
                this.timer += Time.deltaTime;
                return;
            }

            CheckPatrolPointRandom();
            this.timer = 0;
        }
        this.petPrefabCtrl.NavMeshAgent.SetDestination(patrolPointRandom);
        this.UpdateSpeet(1.5f, 5);
        this.UpdateAnimation(true, false);

    }

    protected virtual void ChasePlayer()
    {
        this.UpdateSpeet(5, 5);
        this.UpdateAnimation(true, false);
        this.patrolPointRandom = this.petCtrl.GameCtrl.PlayerCtrl.transform.position;
        this.petPrefabCtrl.NavMeshAgent.SetDestination(patrolPointRandom);

        Vector3 distance = this.petCtrl.GameCtrl.PlayerCtrl.transform.position - transform.parent.position;
        if (distance.magnitude > 20)
        {
            this.transform.parent.position = this.petCtrl.GameCtrl.PlayerCtrl.transform.position;
        }
    }
    protected virtual void MoveThenAttack()
    {
        this.UpdateSpeet(3, 5);
        this.UpdateAnimation(true, false);
        if (this.petCtrl.GameCtrl.PlayerCtrl.PlayerRadar.EnemyInAttackRange() == false) return;
        this.petPrefabCtrl.NavMeshAgent.SetDestination(this.petCtrl.GameCtrl.PlayerCtrl.PlayerRadar.TargetNearest.transform.parent.position);
    }
    private void AttackEnemy()
    {
        float timeAnimation = 3f;

        this.petPrefabCtrl.NavMeshAgent.SetDestination(transform.parent.position);
        this.UpdateAnimation(false, false);

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown + timeAnimation)
        {
            if (this.PetPrefabCtrl.PetRadarAttack.TargetNearest == null) return;
            transform.parent.LookAt(this.PetPrefabCtrl.PetRadarAttack.TargetNearest.transform.parent.position);
            this.PetPrefabCtrl.Animator.SetInteger("AttackIndex", Random.Range(0, 2));
            this.PetPrefabCtrl.Animator.SetTrigger("Attack");
            this.UpdateAnimation(false, true);
            attackTimer = 0f;
        }
    }
}
