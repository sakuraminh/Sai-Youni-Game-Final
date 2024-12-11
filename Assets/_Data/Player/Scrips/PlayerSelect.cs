using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSelect : PlayerAbs
{
    [SerializeField] protected List<EnemyCheck> enemyChecks = new();
    public List<EnemyCheck> EnemyChecks => this.enemyChecks;
    protected virtual void Update()
    {
        this.Selecting();
    }
    public virtual void Selecting()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (playerCtrl.GameCtrl.Helper.InputManage.GetMouseButtonDown0())
        {
            int layerMask = LayerMask.GetMask("Ground", "EnemyCheck", "Obstacle");

            Ray ray = Camera.main.ScreenPointToRay(playerCtrl.GameCtrl.Helper.InputManage.MousePosition());

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    //if (this.enemyChecks.Count > 0)
                    //{
                    //    this.enemyChecks[0].transform.parent.transform.Find("EnemyModel").GetComponent<Renderer>().material.color = this.enemyChecks[0].DefaultColor;
                    //}
                    //this.enemyChecks.Clear();
                    playerCtrl.PlayerMoving.SetTargetPosition(hit.point);
                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("EnemyCheck"))
                {
                    EnemyCheck enemyCheck = (hit.collider.transform.GetComponent<EnemyCheck>());

                    if (enemyCheck != null)
                    {
                        if (this.enemyChecks.Count > 0)
                        {
                            this.enemyChecks[0].transform.parent.transform.Find("EnemyModel").GetComponent<Renderer>().material.color = this.enemyChecks[0].DefaultColor;
                        }
                        this.enemyChecks.Clear();
                        this.enemyChecks.Add(enemyCheck);
                        enemyCheck.transform.parent.transform.Find("EnemyModel").GetComponent<Renderer>().material.color = Color.red;
                    }

                }
            }

        }
    }
}

