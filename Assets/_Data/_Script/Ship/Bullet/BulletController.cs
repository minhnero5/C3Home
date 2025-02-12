using UnityEngine;

public class BulletController : ThanguMonoBehavior
{
    [SerializeField] private DamageSender damageSender;

    public DamageSender DamageSender { get => damageSender;}
  
    [SerializeField] private BulletDespawn bulletDeSpawner;
    public BulletDespawn BulletDeSpawner { get => bulletDeSpawner; }

    [SerializeField] private Transform shooter;

    public Transform Shooter => shooter;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDeSpawn();
    }

    protected virtual void LoadDamageSender()
    {
        if (damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    protected virtual void LoadBulletDeSpawn()
    {
        if (bulletDeSpawner) return;
        this.bulletDeSpawner = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletSpawner", gameObject);
    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
