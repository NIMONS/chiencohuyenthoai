using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjcet : CCHTMonoBehaviour
{
    [SerializeField] protected float speedObj = 0.5f;
    protected override void Update()
    {
        base.Update();
        this.MoveObj();
    }

    protected virtual void MoveObj()
    {
        var step = speedObj * Time.deltaTime;
        transform.Translate(Vector3.up * step);
    }
}
