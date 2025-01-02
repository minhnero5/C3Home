using UnityEngine;

public class JunkController : ThanguMonoBehavior
{
    [SerializeField] private Transform model;

    public Transform Model { get => model; }
   
    [SerializeField] private JunkDespawn junkDespawn;

    public JunkDespawn JunkDespawn { get => junkDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDeSpawner();
    }

    protected virtual void LoadModel()
    {
        if (this.Model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadJunkDeSpawner()
    {
        if (this.JunkDespawn != null) return;
        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": LoadJunkDeSpawner", gameObject);
    }
}
