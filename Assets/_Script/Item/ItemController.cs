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

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem()
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": LoadItemDespawn", gameObject);
    }

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = new ItemInventory();
        this.itemInventory.itemProfileSO = itemInventory.itemProfileSO;
        this.itemInventory.itemCount = itemInventory.itemCount;
        this.itemInventory.upgradeLevel = itemInventory.upgradeLevel;
    }

    protected virtual void LoadItemInventory()
    { 
        if(this.itemInventory.itemProfileSO != null) return;
        ItemCode itemCode=ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfileSO=ItemProfileSO.FindByItemcode(itemCode);
        this.itemInventory.itemProfileSO = itemProfileSO;
        this.ResetItem();
        
    }

    protected virtual void ResetItem()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;
    }
}
