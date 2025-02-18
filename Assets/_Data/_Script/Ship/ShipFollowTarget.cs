using System;
using UnityEngine;

public class ShipFollowTarget : ObjectMovement
{

    [SerializeField] protected Transform target;
    protected override void FixedUpdate()
    {
        this.GetTargetPosition();
        base.FixedUpdate();

    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = this.target.position;
        this.targetPosition.z = 0;
    }

}
