using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : InventoryAbstract
{
    //[SerializeField] protected Inventory inventory;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rig;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadInventory();
        this.LoadCollider();
        this.LoadRigidbody();

    }

    //protected virtual void LoadInventory()
    //{
    //    if (this.inventory != null) return;
    //    this.inventory = transform.parent.GetComponent<Inventory>();
    //    Debug.LogWarning(transform.name + ": LoadInventory", gameObject);
    //}

    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.25f;
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rig != null) return;
        this._rig = transform.GetComponent<Rigidbody>();
        this._rig.useGravity = false;
        this._rig.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemCode itemCode = itemPickupable.GetItemCode();
        if (this.inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }
        Debug.Log("co the pick");
    }
}
