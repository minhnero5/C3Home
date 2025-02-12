using UnityEngine;

public abstract class ShootableObjectController : ThanguMonoBehavior
{
    [SerializeField] private Transform model;

    public Transform Model => model;

    [SerializeField] private DeSpawn despawn;

    public DeSpawn _Despawn => despawn;

    [SerializeField] private ShootableObjectSO shootableObject;

    public ShootableObjectSO ShootableObject => shootableObject;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDeSpawner();
        this.LoadSO();
    }

    protected virtual void LoadModel()
    {
        if (this.Model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadDeSpawner()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<DeSpawn>();
        Debug.Log(transform.name + ": LoadJunkDeSpawner", gameObject);
    }

    protected virtual void LoadSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/"+ this.GetObjectTypeString() + "/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ":Load ShootableObjectSO" + resPath, gameObject);
    }

    protected abstract string GetObjectTypeString();

}
