using System;
using Unity.Mathematics;
using UnityEngine;

public class ObjectMoveFoward : ObjectMovement
{
    [SerializeField] protected Transform target;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();

    }

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = transform.Find("MoveTarget");
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();

    }

    protected virtual void GetMousePosition()
    {
        this.targetPosition = target.position;
        this.targetPosition.z = 0;
    }


}
