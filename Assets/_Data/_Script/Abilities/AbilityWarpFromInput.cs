using UnityEngine;

public class AbilityWarpFromInput : AbilityWarp
{


    protected override void Update()
    {
        base.Update();
        this.UpdateKeyDirection();
    }

    protected virtual void UpdateKeyDirection()
    {
        this.keyDirection = InputManager.Instance.Direction;

        if (this.keyDirection.x == 1) Debug.Log("Left");
        if (this.keyDirection.y == 1) Debug.Log("Right");
        if (this.keyDirection.z == 1) Debug.Log("Up");
        if (this.keyDirection.w == 1) Debug.Log("Down");

    }
}
