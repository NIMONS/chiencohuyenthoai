using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : CCHTMonoBehaviour
{
    [SerializeField] protected float speedRotation=15f;

    protected override void Update()
    {
        base.Update();
        this.ObjRotation();
    }

    protected void ObjRotation()
    {
        float step = this.speedRotation * Time.deltaTime;
        transform.parent.Rotate(0, 0, step);
    }
}
