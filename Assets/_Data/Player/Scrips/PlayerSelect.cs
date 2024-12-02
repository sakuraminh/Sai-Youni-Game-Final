using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSelect : PlayerAbs
{
    [SerializeField] protected LayerMask groundLayer;

    protected virtual void Update()
    {
        this.Selecting();
    }
    public virtual void Selecting()
    {
        if (HelperSingleton.Instance.InputManage.GetMouseButtonDown0())
        {
            Ray ray = Camera.main.ScreenPointToRay(HelperSingleton.Instance.InputManage.MousePosition());

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);
                playerCtrl.PlayerMoving.SetTargetPosition(hit.point);
            }

        }
    }
}
