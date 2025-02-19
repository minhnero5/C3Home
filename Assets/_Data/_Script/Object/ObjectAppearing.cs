using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAppearing : ThanguMonoBehavior
{
    [SerializeField] protected bool isAppearing = false;
    [SerializeField] protected bool appeared = false;

    [SerializeField] protected List<IObjectAppearObserver> observers = new List<IObjectAppearObserver>();
    public bool IsAppearing => isAppearing;
    public bool Appeared => appeared;

    protected override void Start()
    {
        base.Start();
        this.OnAppearStart();
    }
    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected abstract void Appearing();


    protected virtual void Appear()
    {
        this.appeared = true;
        this.isAppearing = false;
        this.OnAppearFinish();
    }

    protected virtual void OnAppearStart()
    {
        foreach (IObjectAppearObserver observer in this.observers)
        {
            observer.OnAppearStart();
        }

    }

    protected virtual void OnAppearFinish()
    {
        foreach (IObjectAppearObserver observer in this.observers)
        {
            observer.OnAppearFinish();
        }

    }

    public virtual void ObserverAdd(IObjectAppearObserver observer)
    {
        this.observers.Add(observer);
    }
}
