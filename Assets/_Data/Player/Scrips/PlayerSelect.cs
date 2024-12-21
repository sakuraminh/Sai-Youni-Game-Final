using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSelect : PlayerAbs
{
    [SerializeField] protected List<EnemyCheck> enemyChecks = new();
    public List<EnemyCheck> EnemyChecks => this.enemyChecks;

    [SerializeField] protected Vector3 targetPosition;
    public Vector3 TargetPosition => this.targetPosition;

    protected float doubleClickThreshold = 0.3f;
    protected float lastClickTime;
    protected int clickCount;


    protected virtual void Update()
    {
        this.Selecting();
    }
    public virtual void Selecting()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (playerCtrl.GameCtrl.Helper.InputManage.GetMouseButtonDown0())
        {

            float currentTime = Time.time;
            if (currentTime - lastClickTime < doubleClickThreshold)
            {
                clickCount++;
            }
            else
            {
                clickCount = 1;
            }
            lastClickTime = currentTime;

            this.OnClick();
        }
    }

    protected virtual void OnClick()
    {
        int layerMask = LayerMask.GetMask("Ground", "EnemyCheck", "Obstacle");

        Ray ray = Camera.main.ScreenPointToRay(playerCtrl.GameCtrl.Helper.InputManage.MousePosition());

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                playerCtrl.PlayerMoving.SetTargetPosition(hit.point);
                this.targetPosition = hit.point;
                this.enemyChecks.Clear();
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("EnemyCheck"))
            {
                if (clickCount == 1)
                {
                    //Debug.Log("SingleClick");
                    EnemyCheck enemyCheck = (hit.collider.transform.GetComponent<EnemyCheck>());

                    if (enemyCheck != null)
                    {
                        this.enemyChecks.Clear();
                        this.enemyChecks.Add(enemyCheck);
                    }
                    else this.enemyChecks.Clear();
                }
                else if (clickCount == 2)
                {
                    //Debug.Log("DoubleClick");
                    this.InvokeDefaultAttackEnemy();
                }

            }
        }
    }
    protected virtual void InvokeDefaultAttackEnemy()
    {
        if (this.enemyChecks.Count > 0)
        {
            this.playerCtrl.PlayerAttack.DefaultAttackEnemy(this.enemyChecks[0]);

            if (playerCtrl.PlayerDameReceive.IsDead == false) Invoke(nameof(InvokeDefaultAttackEnemy), 3f);
        }
    }
}

