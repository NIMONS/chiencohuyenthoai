using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByDistance : CCHTMonoBehaviour
{
    protected override void Update()
    {
        base.Update();
        this.DestroyObj();
    }

    public virtual void DestroyObj()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 bulletPos = transform.position;
        float caculaDisof2pos = Vector3.Distance(cameraPos, bulletPos);
        if (caculaDisof2pos > 20f) Destroy(transform.parent.gameObject);
    }
}
