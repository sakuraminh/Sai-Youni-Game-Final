using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar<T> : MMonoBehaviour where T : MMonoBehaviour
{
    [SerializeField] protected T targetNearest;
    public T TargetNearest => this.targetNearest;

    [SerializeField] protected List<T> targetChecks = new();

    protected virtual void Update()
    {
        this.FindTargetByDistance(targetChecks);
    }
    protected virtual void FindTargetByDistance(List<T> targetCheck)
    {
        if (this.targetChecks.Count == 0)
        {
            this.targetNearest = default;
            return;
        }

        float distanceNearest = Mathf.Infinity;
        float distancePlayer = 0;

        foreach (T target in this.targetChecks)
        {
            distancePlayer = Vector3.Distance(transform.parent.position, target.transform.parent.position);
            if (distancePlayer < distanceNearest)
            {
                distanceNearest = distancePlayer;
                this.targetNearest = target;
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        T targetCheck = collider.GetComponent<T>();
        if (targetCheck == null) return;
        this.AddTargetCheck(targetCheck);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (this.targetChecks.Count == 0) return;
        T targetCheck = collider.GetComponent<T>();
        if (targetCheck == null) return;
        this.RemoveTargetCheck(targetCheck);
    }

    protected virtual void AddTargetCheck(T targetCheck)
    {
        this.targetChecks.Add(targetCheck);
    }

    protected virtual void RemoveTargetCheck(T targetCheck)
    {
        this.targetChecks.Remove(targetCheck);
    }
}
