using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageSender : ThanguMonoBehavior
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReciver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReciver == null) return;
        this.Send(damageReciver);
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }

}
