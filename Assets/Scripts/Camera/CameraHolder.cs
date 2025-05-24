using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MoveObjcet
{
    [SerializeField] protected Camera _camera;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected void LoadCamera()
    {
        if (this._camera != null) return;
        this._camera=transform.GetComponentInChildren<Camera>();
        Debug.LogWarning(transform.name + ": LoadCamera", gameObject);
    }
}
