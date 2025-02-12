using System;
using UnityEngine;

public class LevelByDistance : Level
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected float distancePerLevel = 10f;

    protected override void Start()
    {
        base.Start();
        
    }

    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
        Debug.Log(this.target);

    } 

    protected virtual void Leveling()
    {
        if (this.target == null) return;
        this.distance = Vector3.Distance(transform.position, target.position);
        int newLevel = this.GetLevelByDistance();
        this.LevelSet(newLevel);
    }


    protected virtual int GetLevelByDistance()
    {
        return Mathf.FloorToInt(this.distance / this.distancePerLevel) + 1;
    }

}
