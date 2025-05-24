using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DestroyByDistance
{
    public void StarEffectAndDestroy(GameObject obj)
    {
        StartCoroutine(this.EffectAndDestroy(obj));
    }

    protected IEnumerator EffectAndDestroy(GameObject obj)
    {
        yield return new WaitForEndOfFrame();
        Destroy(obj);
    }
}
