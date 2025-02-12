using UnityEngine;

public class ShootableObjectDamageReceiver : DamageReceiver
{
    [SerializeField] protected ShootableObjectController controller;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadController();
    }

    protected virtual void LoadController()
    {
        if (this.controller != null) return;
        this.controller = transform.parent.GetComponent<ShootableObjectController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.controller._Despawn.DespawnObject();
                       
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.controller.ShootableObject.dropList,dropPos,dropRot);
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }
    protected override void Reborn()
    {
        this.hpMax = this.controller.ShootableObject.hpMax;
        base.Reborn();
        //Debug.Log("Reborn",gameObject);
    }
}
