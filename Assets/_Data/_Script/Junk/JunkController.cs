using UnityEngine;

public class JunkController : ThanguMonoBehavior
{
    [SerializeField] private Transform model;

    public Transform Model { get => model; }
   
    [SerializeField] private JunkDespawn junkDespawn;

    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] private ShootableObjectSO shootableObject;

    public ShootableObjectSO ShootableObject => shootableObject;
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
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/Junk/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ":Load ShootableObjectSO" + resPath, gameObject);
    }

}
