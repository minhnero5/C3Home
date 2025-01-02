using UnityEngine;

public class BulletDmgSender : DamageSender
{
    [SerializeField] protected BulletController bulletController;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullet();
    }

    protected virtual void LoadBullet()
    {
        if (this.bulletController != null) return;
        this.bulletController = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletController", gameObject);
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        this.bulletController.BulletDeSpawner.DespawnObject();
    }
}
