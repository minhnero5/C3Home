using System;
using UnityEngine;

public class ShipFollowMouse : ObjectMovement
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
