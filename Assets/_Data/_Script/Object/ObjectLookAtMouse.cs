using System;
using Unity.Mathematics;
using UnityEngine;

public class ObjectLookAtMouse : ObjectLookAtTarget
{

    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();

    }

    protected virtual void GetMousePosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPosition;
        this.targetPosition.z = 0;
    }

}
