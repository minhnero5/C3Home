using UnityEngine;

public class ItemController : ThanguMonoBehavior
{
    [SerializeField] protected ItemDespawn itemDespawn;

    public ItemDespawn _itemDespawn => itemDespawn;

    [SerializeField] protected ItemInventory itemInventory;

    public ItemInventory _itemInventory => itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
    }
    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": LoadItemDespawn", gameObject);
    }

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }
}
