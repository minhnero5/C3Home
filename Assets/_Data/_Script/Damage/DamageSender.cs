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
        this.CreateFXImpact();
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }

    protected virtual void CreateFXImpact()
    {
        string fxName = this.GetImpactFX();

        Vector3 hitPos = transform.position;
        Quaternion hitRos = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRos);
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX()
    {
        return FXSpawner.impact1;
    }
}
