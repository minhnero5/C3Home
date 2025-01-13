using UnityEngine;


[RequireComponent (typeof(SphereCollider))]
public class ItemPickupable : ThanguMonoBehavior
{
    [SerializeField] protected SphereCollider _collider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (_collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.1f;
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);

    }
}
