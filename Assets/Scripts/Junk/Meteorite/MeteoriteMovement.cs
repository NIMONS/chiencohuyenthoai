using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteMovement : CCHTMonoBehaviour
{
    [SerializeField] protected SpaceshipCtrl spaceshipCtrl;
    public SpaceshipCtrl SpaceshipCtrl => spaceshipCtrl;
    [SerializeField] protected float speedMove = 2f;
    [SerializeField] protected float speedRotate = 10f;

    private Vector3 initialTargetPosition;
    private Vector3 moveDirection;
    private bool reachedTarget = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpaceshipCtrl();
    }

    protected void LoadSpaceshipCtrl()
    {
        if (this.spaceshipCtrl != null) return;
        this.spaceshipCtrl = GameObject.FindObjectOfType<SpaceshipCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpaceshipCtrl", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.SetPosTargetTo();
    }

    protected override void Update()
    {
        base.Update();
        this.ObjMovement();
        this.ObjRotation();
    }

    protected void ObjRotation()
    {
        transform.parent.Rotate(0,0,this.speedRotate * Time.deltaTime);
    }

    protected void ObjMovement()
    {
        if (!reachedTarget)
        {
            transform.parent.position = Vector3.MoveTowards(transform.parent.position,
                                                        this.initialTargetPosition,
                                                        this.speedMove * Time.deltaTime);
            if (transform.parent.position == initialTargetPosition) this.reachedTarget = true;
        }
        else
        {
            transform.parent.position += this.moveDirection * this.speedMove * Time.deltaTime;
        }
    }

    protected void SetPosTargetTo()
    {
        Transform targetPosition = spaceshipCtrl.transform;
        this.initialTargetPosition = targetPosition.position;
        this.moveDirection = (this.initialTargetPosition - transform.position).normalized;
    }
}
