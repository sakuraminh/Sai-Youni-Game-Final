using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManage : MMonoBehaviour
{
    public virtual float LoadHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public virtual float LoadVertical()
    {
        return Input.GetAxis("Vertical");
    }

    public virtual bool GetMouseButtonDown0()
    {
        return Input.GetMouseButtonDown(0);
    }
    public virtual Vector3 MousePosition()
    {
        return Input.mousePosition;
    }
}
