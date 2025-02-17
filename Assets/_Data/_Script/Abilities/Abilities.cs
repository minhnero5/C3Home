using UnityEngine;

public class Abilities : ThanguMonoBehavior
{
    [SerializeField] protected AbilityObjectController abilityController;
    public AbilityObjectController AbilityController => abilityController;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityController();
    }
    protected virtual void LoadAbilityController()
    {
        if (this.abilityController != null) return;
        this.abilityController = transform.parent.GetComponent<AbilityObjectController>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }
}
