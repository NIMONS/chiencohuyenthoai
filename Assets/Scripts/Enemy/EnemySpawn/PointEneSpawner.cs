using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEneSpawner : MoveObjcet
{
    [SerializeField] protected List<Transform> listPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListPoints();
    }

    protected void LoadListPoints()
    {
        if (this.listPoints.Count > 0) return;
        Transform currentTransfrom = transform;
        foreach (Transform t in currentTransfrom) 
        {
            this.listPoints.Add(t);
        }
        Debug.LogWarning(transform.name + ": LoadListPoints", gameObject);
    }

}
