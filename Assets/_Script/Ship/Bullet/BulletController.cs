using UnityEngine;

public class BulletController : ThanguMonoBehavior
{
    [SerializeField] private DamageSender damageSender;

    public DamageSender DamageSender { get => damageSender;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
    }

    protected virtual void LoadDamageSender()
    {
        if (damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }
}
