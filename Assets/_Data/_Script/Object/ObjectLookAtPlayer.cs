using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtPlayer : ObjectLookAtTarget
{
    [SerializeField] protected GameObject player;
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }
    protected virtual void GetMousePosition()
    {
        this.targetPosition = this.player.transform.position;
        this.targetPosition.z = 0;
    }

}
