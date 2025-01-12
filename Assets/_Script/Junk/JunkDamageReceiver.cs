using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [SerializeField] protected JunkController junkController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.junkController.JunkDespawn.DespawnObject();
                       
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkController.JunkSO.dropList,dropPos,dropRot);
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
        this.hpMax = this.junkController.JunkSO.hpMax;
        base.Reborn();
        Debug.Log("Reborn",gameObject);
    }
}
