using UnityEngine;

public class ObjectModifyAbstract : ThanguMonoBehavior
{
    [SerializeField] protected ShootableObjectController shootableObjectController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectController();
    }

    protected virtual void LoadShootableObjectController()
    {
        if (this.shootableObjectController != null) return;
        this.shootableObjectController = transform.GetComponent<ShootableObjectController>();
        Debug.LogWarning(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }
}
