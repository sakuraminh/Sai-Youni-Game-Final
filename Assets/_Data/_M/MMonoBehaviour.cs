using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Start()
    {
        //override
    }

    protected virtual void OnEnable()
    {
        //override
    }
    protected virtual void OnDisable()
    {
        //override
    }

    protected virtual void LoadComponents()
    {
        //override
    }
}
