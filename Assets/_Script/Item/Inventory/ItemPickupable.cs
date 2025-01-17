using UnityEngine;


[RequireComponent (typeof(SphereCollider))]
public class ItemPickupable : ItemAbstract
{
    [SerializeField] protected SphereCollider _collider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    public static ItemCode StringToItemcode(string itemName)
    {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode),itemName);
    }    

    protected virtual void LoadCollider()
    {
        if (_collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.2f;
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);

    }

    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.StringToItemcode(transform.parent.name);
    }

    public virtual void Picked()
    {
        this._itemController._itemDespawn.DespawnObject();
    }

    protected virtual void OnMouseDown()
    {
        PlayerController.Instance.PlayerPickup.ItemPickup(this);
    }
}
