using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MInputManage : MSingleton<MInputManage>
{
    public virtual float LoadHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public virtual float LoadVertical()
    {
        return Input.GetAxis("Vertical");
    }
}
