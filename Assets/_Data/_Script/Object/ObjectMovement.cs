using System;
using Unity.Mathematics;
using UnityEngine;

public class ObjectMovement : ThanguMonoBehavior
{

    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float distance = 1;
    [SerializeField] protected float minDistance = 1;

    protected virtual void FixedUpdate()
    {
        
       
        this.Moving();
    }

    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    protected virtual void Moving()
    {
        this.distance=Vector3.Distance(transform.position, this.targetPosition);
        if (this.distance < this.minDistance) return;

        Vector3 newPos = Vector3.Lerp(transform.position, targetPosition, this.speed);
        transform.parent.position = newPos;
    }
}
