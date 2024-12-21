using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPointOnNavMesh : MMonoBehaviour
{
    public virtual bool RandomPoint(Vector3 spawnPointPos, float range, float validRange, out Vector3 result)
    {
        Vector3 randomPoint = spawnPointPos + Random.insideUnitSphere * range;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, validRange, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
