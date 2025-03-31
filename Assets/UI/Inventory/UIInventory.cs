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
    protected virtual void ClearItems()
    {
        this.inventoryController.UIInventoryItemSpawner.ClearItems();
    }

    protected virtual void SortItems()
    {
        if (this.inventorySort == InventorySort.NoSort) return;
        Debug.Log("===== Short By Name=====");

        int itemCount = this.inventoryController.Content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        ItemProfileSO currentProfile, nextProfile;
        string currentName, nextName;
        int currentCount,nextCount;

        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            currentItem = this.inventoryController.Content.GetChild(i);
            nextItem = this.inventoryController.Content.GetChild(i + 1);

            currentUIItem = currentItem.GetComponent<UIItemInventory>();
            nextUIItem = nextItem.GetComponent<UIItemInventory>();

            currentProfile = currentUIItem.ItemInventory.itemProfileSO;
            nextProfile = nextUIItem.ItemInventory.itemProfileSO;

            bool isSwap = false;
            switch (this.inventorySort)
            {
                case InventorySort.ByName:
                    currentName = currentProfile.itemName;
                    nextName = nextProfile.itemName;
                    isSwap = string.Compare(currentName, nextName) == 1;
                    Debug.Log(i + ": " + currentName + " " + nextName + "=" + isSwap);
                    break;
                case InventorySort.ByCount:
                    currentCount = currentUIItem.ItemInventory.itemCount;
                    nextCount = nextUIItem.ItemInventory.itemCount;
                    isSwap = currentCount < nextCount;
                    Debug.Log("InventorySort.ByCount");
                    break;
            }

            if (isSwap)
            {
                this.SwapItem(currentItem, nextItem);
                isSorting = true;
            }


        }

        if (isSorting)
        {
            this.SortItems();//?? quy
        }
    }



    

    protected virtual void SwapItem(Transform currentItem,Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }
}
