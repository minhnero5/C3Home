using Unity.Mathematics;
using UnityEngine;

public class ShipShootByDistance : ShipShootingManager
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistance = 3f;


    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(transform.position, target.position);
        this.isShooting = this.distance < shootDistance;
        return this.isShooting;
    }

}
