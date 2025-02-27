using UnityEngine;

public class ObjectAppearWithoutShoot : ShootableObjectAbstract,IObjectAppearObserver
{
    [SerializeField] protected ObjectAppearing objectAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResigsterAppearEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectAppearWithoutShoot();
    }

    protected virtual void LoadObjectAppearWithoutShoot()
    {
        if (this.objectAppearing != null) return;
        this.objectAppearing = GetComponent<ObjectAppearing>();
        Debug.Log(transform.name + ": LoadObjectAppearing", gameObject);
    }

    protected virtual void ResigsterAppearEvent()
    {
        this.objectAppearing.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        this.ShootableObjectController.ObjectShooting.gameObject.SetActive(false);
        this.ShootableObjectController.ObjectLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.ShootableObjectController.ObjectShooting.gameObject.SetActive(true);
        this.ShootableObjectController.ObjectLookAtTarget.gameObject.SetActive(true);

        this.ShootableObjectController.Spawner.Hold(transform.parent);
    }
}
