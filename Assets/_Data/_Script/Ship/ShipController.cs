using UnityEngine;

public class ShipController : AbilityObjectController
{
    [SerializeField] protected Inventory inventory;

    public Inventory Inventory => inventory;

    protected override string GetObjectTypeString()
    {
        return ObjectType.Ship.ToString();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
        Debug.LogWarning(transform.name + ": LoadInventory", gameObject);
    }
}
