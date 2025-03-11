using UnityEngine;

public abstract class ShootableObjectController : ThanguMonoBehavior
{
    [SerializeField] private Transform model;

    public Transform Model => model;

    [SerializeField] private DeSpawn despawn;

    public DeSpawn _Despawn => despawn;

    [SerializeField] private ShootableObjectSO shootableObject;

    public ShootableObjectSO ShootableObject => shootableObject;

    [SerializeField] private ObjectShooting objectShooting;

    public ObjectShooting ObjectShooting => objectShooting;

    [SerializeField] private ObjectMovement objectMovement;

    public ObjectMovement ObjectMovement => objectMovement;

    [SerializeField] private ObjectLookAtTarget objectLookAtTarget;

    public ObjectLookAtTarget ObjectLookAtTarget => objectLookAtTarget;

    [SerializeField] private Spawner spawner;

    public Spawner Spawner => spawner;

    [SerializeField] private DamageReceiver damageReceiver;

    public DamageReceiver DamageReceiver => damageReceiver;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDeSpawner();
        this.LoadSO();
        this.LoadObjectShooting();
        this.LoadObjMovement();
        this.LoadObjLookAtTarget();
        this.LoadSpawner();
        this.LoadDamageReciever();
    }

    protected virtual void LoadModel()
    {
        if (this.Model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadObjectShooting()
    {
        if (this.objectShooting != null) return;
        this.objectShooting = GetComponentInChildren<ObjectShooting>();
        Debug.Log(transform.name + ": LoadObjectShooting", gameObject);
    }

    protected virtual void LoadObjMovement()
    {
        if (this.objectMovement != null) return;
        this.objectMovement = GetComponentInChildren<ObjectMovement>();
        Debug.LogWarning(transform.name + ": LoadObjMovement", gameObject);
    }

    protected virtual void LoadObjLookAtTarget()
    {
        if (this.objectLookAtTarget != null) return;
        this.objectLookAtTarget = GetComponentInChildren<ObjectLookAtTarget>();
        Debug.LogWarning(transform.name + ": LoadObjLookAtTarget", gameObject);
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
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = this.transform.parent?.parent?.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadDamageReciever()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }

    protected abstract string GetObjectTypeString();

}
