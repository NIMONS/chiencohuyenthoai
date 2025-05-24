using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CCHTMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 10f;
    protected Vector3 targetPosition;
    [SerializeField] protected bool isMoving = false;
    [SerializeField] protected float SpeedifNotMove = 0.5f;

    protected override void Update()
    {
        base.Update();
        this.SpaceshipMovement();
    }

    protected void SpaceshipMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            this.isMoving = true;

        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f;
            this.targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        }

        if (Input.GetMouseButtonUp(0)) this.isMoving=false;

        if (this.isMoving)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetPosition, step);

            float disBetweenMouseAndShip = Vector3.Distance(transform.parent.position, targetPosition);
            
        }

        if (!this.isMoving)
        {
            float step = SpeedifNotMove * Time.deltaTime;
            transform.parent.Translate(Vector3.up * step);
        }
    }
}
