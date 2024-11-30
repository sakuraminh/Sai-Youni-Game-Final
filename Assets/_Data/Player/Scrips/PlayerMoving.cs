using UnityEngine;

public class PlayerMoving : PlayerAbs
{
    [Header("PlayerMoving")]

    [SerializeField] protected float moveSpeed = 10;

    [SerializeField] protected bool isMoving;

    [SerializeField] protected Vector2 input;

    protected virtual void Update()
    {
        this.UpdateInput();
        this.IsMoving();
        this.UpdateAnimator();
    }
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void UpdateInput()
    {
        this.input.x = MInputManage.Instance.LoadHorizontal();
        this.input.y = MInputManage.Instance.LoadVertical();
    }
    public virtual bool IsMoving()
    {
        this.isMoving = this.input != Vector2.zero;
        return this.input != Vector2.zero;
    }
    protected virtual void UpdateAnimator()
    {
        this.playerCtrl.Animator.SetBool("isMoving", this.IsMoving());
        this.playerCtrl.Animator.SetFloat("InputX", this.input.x);
        this.playerCtrl.Animator.SetFloat("InputY", this.input.y);
    }
    protected virtual Vector3 UpdateMoveDirection()
    {
        Vector3 forward = this.playerCtrl.MainCamera.transform.forward.normalized;
        Vector3 right = this.playerCtrl.MainCamera.transform.right.normalized;

        forward.y = 0;
        right.y = 0;

        return (forward * this.input.y + right * this.input.x).normalized;
    }
    protected virtual void Moving()
    {
        if (this.isMoving == false) return;

        Vector3 velocity = this.UpdateMoveDirection() * this.moveSpeed;
        this.playerCtrl.Rigidbody.MovePosition(this.playerCtrl.Rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
