using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSelect : PlayerAbs
{
    [SerializeField] protected LayerMask groundLayer;

    protected virtual void Update()
    {
        this.Selecting();
    }
    public virtual void Selecting()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (playerCtrl.Helper.InputManage.GetMouseButtonDown0())
        {
            Ray ray = Camera.main.ScreenPointToRay(playerCtrl.Helper.InputManage.MousePosition());

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);
                playerCtrl.PlayerMoving.SetTargetPosition(hit.point);
            }

        }
    }
}
