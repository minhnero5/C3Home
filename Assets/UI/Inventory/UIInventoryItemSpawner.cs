using UnityEngine;

public class UIInventoryItemSpawner : Spawner
{
    private static UIInventoryItemSpawner instance;

    public static UIInventoryItemSpawner Instance { get => instance; }

    public static string normalItem = "UIItem";

    [SerializeField] protected UIInventoryController inventoryController;
    public UIInventoryController UIInventoryController => inventoryController;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryController();
    }
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("There is more UIInventoryItemSpawner than 1 instance");
        UIInventoryItemSpawner.instance = this;

    }

    protected override void LoadHolder()
    {
        this.LoadUIInventoryController();

        if (this.holderPool != null) return;
        this.holderPool = this.inventoryController.Content;
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }
    protected virtual void LoadUIInventoryController()
    {
        if (this.inventoryController != null) return;
        this.inventoryController = transform.parent.GetComponent<UIInventoryController>();
        Debug.LogWarning(transform.name + ": LoadUIInventoryControllertent", gameObject);
    }

    public virtual void ClearItems()
    {
        foreach (Transform item in this.holderPool)
        {
            this.Despawn(item);
        }
    }

    public virtual void SpawnItems(ItemInventory item)
    {
        Transform uiItem = this.inventoryController.UIInventoryItemSpawner.Spawn(UIInventoryItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        UIItemInventory itemInventory = uiItem.GetComponent<UIItemInventory>();
        itemInventory.ShowItem(item);

        uiItem.gameObject.SetActive(true);
    }


}
