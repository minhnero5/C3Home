using UnityEngine;

public abstract class ItemAbstract : ThanguMonoBehavior
{
    [SerializeField] private ItemController itemController;

    public ItemController _itemController { get => itemController; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemController();
    }

    protected virtual void LoadItemController()
    {
        if (this.itemController != null) return;
        this.itemController = transform.parent.GetComponent<ItemController>();
        Debug.Log(transform.name + ": LoadItemController", gameObject);
    }
}
