using UnityEngine;
public class MapLevel : LevelByDistance
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.MapSetTarget();
    }

    protected virtual void MapSetTarget()
    {
        if(this.target != null) return;
        ShipController currentShip = PlayerController.Instance.CurrentShip;
        this.SetTarget(currentShip.transform);

    }
}
