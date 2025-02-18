using UnityEngine;

public abstract class ObjectAppearing : ThanguMonoBehavior
{
    [SerializeField] protected bool isAppearing = false;
    [SerializeField] protected bool appeared = false;

    public bool IsAppearing => isAppearing;
    public bool Appeared => appeared;
    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected abstract void Appearing();


    protected virtual void Appear()
    {
        this.appeared = true;
        this.isAppearing = false;
    }
}
