using UnityEngine;

public abstract class ShootableObjectAbstract : ThanguMonoBehavior
{

    [SerializeField] private ShootableObjectController shootableObjectController;

    public ShootableObjectController ShootableObjectController => shootableObjectController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectController();
    }

    protected virtual void LoadShootableObjectController()
    {
        if (this.shootableObjectController != null) return;
        this.shootableObjectController = transform.parent.GetComponent<ShootableObjectController>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }


}
