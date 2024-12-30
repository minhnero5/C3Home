using UnityEngine;

public class JunkController : ThanguMonoBehavior
{
    [SerializeField] private Transform model;

    public Transform Model { get => model; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.Model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}
