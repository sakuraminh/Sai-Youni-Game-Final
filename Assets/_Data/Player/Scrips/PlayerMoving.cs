using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoving : PlayerAbs
{
    [Header("PlayerMoving")]

    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] protected LayerMask ground;

    [SerializeField] protected float moveSpeed = 10;

    [SerializeField] protected bool isGround;

    [SerializeField] protected bool isMoving;
    public bool IsMoving => this.isMoving;

    protected virtual void Update()
    {
        //this.CheckUI();
        this.UpdateAnimator();

    }
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    //protected virtual void CheckUI()
    //{
    //    if (EventSystem.current.IsPointerOverGameObject())
    //    {
    //        this.isMoving = false;
    //        return;
    //    }
    //    this.isMoving = true;
    //}
    protected virtual void UpdateAnimator()
    {
        this.playerCtrl.Animator.SetBool("isMoving", this.isMoving);
    }
    protected virtual void Moving()
    {
        if (playerCtrl.PlayerDameReceive.IsDead == false)
        {
            if (this.isMoving)
            {
                //if (EventSystem.current.IsPointerOverGameObject()) return;

                Vector3 nextPos = Vector3.MoveTowards(transform.parent.position, this.targetPosition, moveSpeed * Time.deltaTime);

                if (Physics.Raycast(new Vector3(nextPos.x, nextPos.y + 10f, nextPos.z), Vector3.down, out RaycastHit hit, Mathf.Infinity, ground))
                {
                    Debug.DrawLine(new Vector3(nextPos.x, nextPos.y + 10f, nextPos.z), hit.point, Color.green, 10f);
                    nextPos.y = hit.point.y;
                }

                transform.parent.position = nextPos;
                transform.parent.LookAt(this.targetPosition);
                transform.parent.rotation = Quaternion.Euler(0, transform.parent.eulerAngles.y, 0);

                if (Vector3.Distance(transform.parent.position, targetPosition) < 0.1f)
                {
                    isMoving = false;
                }
            }
        }
    }
    public virtual void SetTargetPosition(Vector3 newPos)
    {
        this.targetPosition = newPos;
        this.isMoving = true;
    }
}
