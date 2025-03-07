using UnityEngine;

public abstract class BaseAbilities : ThanguMonoBehavior
{
    [SerializeField] protected Abilities abilities;
    public Abilities Abilities => abilities;

    [SerializeField] protected float timer = 2f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isReady = false;

    protected virtual void FixedUpdate()
    {
        this.Timing();
    }

    protected virtual void Update()
    {
        
    }

    protected virtual void Timing()
    {
        if (this.isReady) return;
        this.timer += Time.deltaTime ;
        if (this.timer < this.delay) return;
        this.isReady = true;
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
        this.isReady = false;
        this.timer = 0;
    }
}
