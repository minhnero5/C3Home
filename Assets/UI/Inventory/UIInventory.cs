using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    private static UIInventory instance;

    public static UIInventory Instance => instance;

    protected bool isOpen = true;

    [SerializeField] protected InventorySort inventorySort;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("There is more EnemySpawner than 1 instance");
        UIInventory.instance = this;

    }
    protected override void Start()
    {
        base.Start(); 

        InvokeRepeating(nameof(this.ShowItems),1,1);
        //this.Close();
    }

    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if(this.isOpen ) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        this.UIInventoryController.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        this.UIInventoryController.gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;
        this.ClearItems();
        List<ItemInventory> items = PlayerController.Instance.CurrentShip.Inventory.Items;
        UIInventoryItemSpawner spawner = this.inventoryController.UIInventoryItemSpawner;
        foreach (ItemInventory item in items) 
        {
            spawner.SpawnItems(item);
        }

        this.SortItems();

    }

    protected virtual void SortItems()
    {
        switch(this.inventorySort)
        {
            case InventorySort.ByName:
                Debug.Log("InventorySort.ByName");
                break;
            case InventorySort.ByCount:
                Debug.Log("InventorySort.ByCount");
                break;
            default:
                Debug.Log("InventorySort.NoSort");
                break;
        }
    }

    protected virtual void ClearItems()
    {
        this.inventoryController.UIInventoryItemSpawner.ClearItems();
    }
}
