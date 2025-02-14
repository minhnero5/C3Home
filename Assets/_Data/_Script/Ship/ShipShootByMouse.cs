using UnityEngine;

public class ShipShootByMouse : ShipShootingManager
{
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }

}
