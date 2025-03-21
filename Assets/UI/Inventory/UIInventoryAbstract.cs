using UnityEngine;

public abstract class UIInventoryAbstract : ThanguMonoBehavior
{

    [SerializeField] protected UIInventoryController inventoryController;
    public UIInventoryController UIInventoryController => inventoryController;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryController();
    }

    protected virtual void LoadUIInventoryController()
    {
        if (this.inventoryController != null) return;
        this.inventoryController = transform.parent.GetComponent<UIInventoryController>();
        Debug.LogWarning(transform.name + ": LoadUIInventoryController", gameObject);
    }


}
