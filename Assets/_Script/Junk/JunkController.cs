using UnityEngine;

public class JunkController : ThanguMonoBehavior
{
    [SerializeField] private Transform model;

    public Transform Model { get => model; }
   
    [SerializeField] private JunkDespawn junkDespawn;

    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] private JunkSO junkSO;

    public JunkSO JunkSO => junkSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDeSpawner();
        this.LoadJunkSO();
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

    protected virtual void LoadJunkSO()
    {
        if (this.junkSO != null) return;
        string resPath = "Junk/" + transform.name;
        this.junkSO = Resources.Load<JunkSO>(resPath);
        Debug.LogWarning(transform.name + ":Load JunkSO" + resPath, gameObject);
    }

}
