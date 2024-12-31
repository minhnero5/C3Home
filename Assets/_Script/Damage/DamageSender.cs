using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageSender : ThanguMonoBehavior
{
    [SerializeField] protected float damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReciver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReciver == null) return;
        this.Send(damageReciver);
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
        this.DestroyObject();
    }

    protected virtual void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
