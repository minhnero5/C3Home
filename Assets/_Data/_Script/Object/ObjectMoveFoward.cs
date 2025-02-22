using System;
using Unity.Mathematics;
using UnityEngine;

public class ObjectMoveFoward : ObjectMovement
{
    [SerializeField] protected Transform target;

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
