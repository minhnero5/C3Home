using UnityEngine;

public abstract class BaseAbilities : ThanguMonoBehavior
{
    [SerializeField] protected Abilities abilities;
    public Abilities Abilities => abilities;

    [SerializeField] protected float timer = 2f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isRead = false;

    protected virtual void FixedUpdate()
    {
        this.Timing();
    }

    protected virtual void Timing()
    {
        if (this.isRead) return;
        this.timer += Time.deltaTime ;
        if (this.timer < this.delay) return;
        this.isRead = true;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilities();
    }
    protected virtual void LoadAbilities()
    {
        if (this.abilities != null) return;
        this.abilities = transform.parent.GetComponent<Abilities>();
        Debug.Log(transform.name + ": LoadAbilities", gameObject);
    }  

    public virtual void Active()
    {
        this.isRead = false;
        this.timer = 0;
    }
}
