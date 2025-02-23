using System;
using Unity.Mathematics;
using UnityEngine;

public class ObjectLookAtTarget : ThanguMonoBehavior
{

    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float rotSpeed = 0.001f;


    protected virtual void FixedUpdate()
    {
        
        this.LookAtTarget();
       
    }

    public virtual void SetRotationSpeed(float speedRot)
    {
        this.rotSpeed = speedRot;
    }


    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
        Quaternion targetEuler = Quaternion.Euler(0, 0, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);

        transform.parent.rotation = currentEuler;

    }
}
