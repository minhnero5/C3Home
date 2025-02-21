using System;
using Unity.Mathematics;
using UnityEngine;

public class ObjectMovement : ThanguMonoBehavior
{

    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float rotSpeed = 0.001f;
    [SerializeField] protected float distance = 1;
    [SerializeField] protected float minDistance = 1;

    protected virtual void FixedUpdate()
    {
        
        this.LookAtTarget();
        this.Moving();
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
    protected virtual void Moving()
    {
        this.distance=Vector3.Distance(transform.position, this.targetPosition);
        if (this.distance < this.minDistance) return;

        Vector3 newPos = Vector3.Lerp(transform.position, targetPosition, this.speed);
        transform.parent.position = newPos;
    }
}
