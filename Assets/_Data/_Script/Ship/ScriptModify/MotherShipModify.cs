using UnityEngine;

public class MotherShipModify : ObjectModifyAbstract
{
    [SerializeField] protected float speed = 0.005f;
    [SerializeField] protected float rotSpeed = 0.01f;

    protected override void Start()
    {
        base.Start();
        this.ShipModify();
    }

    protected virtual void ShipModify()
    {
        this.shootableObjectController.ObjectMovement.SetSpeed(this.speed);
        this.shootableObjectController.ObjectLookAtTarget.SetRotationSpeed(this.rotSpeed);
    }
}
