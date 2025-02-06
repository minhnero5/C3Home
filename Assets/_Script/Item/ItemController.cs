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
        this.LoadItemInventory();
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

    protected virtual void LoadItemInventory()
    { 
        if(this.itemInventory.itemProfileSO != null) return;
        ItemCode itemCode=ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfileSO=ItemProfileSO.FindByItemcode(itemCode);
        this.itemInventory.itemProfileSO = itemProfileSO;
        this.itemInventory.itemCount = 1;
        
    }
}
