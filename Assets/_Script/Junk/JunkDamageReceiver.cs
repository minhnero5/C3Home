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
        this.junkController.JunkDespawn.DespawnObject();
    }

    protected override void Reborn()
    {
        this.hpMax = this.junkController.JunkSO.hpMax;
        base.Reborn();
        Debug.Log("Reborn",gameObject);
    }
}
