using UnityEngine;

public class UIInventoryController : ThanguMonoBehavior
{
    [SerializeField] protected Transform content;
    public Transform Content => content;

    [SerializeField] protected UIInventoryItemSpawner inventoryItemSpawner;
    public UIInventoryItemSpawner UIInventoryItemSpawner => inventoryItemSpawner;


    protected override void Start()
    {
        base.Start();
        for (int i = 1; i < 70; i++)
        {
            this.SpawnTest(i);
        }
    }

    protected virtual void SpawnTest(int i)
    {
        Transform uiItem = this.UIInventoryItemSpawner.Spawn(UIInventoryItemSpawner.normalItem,Vector3.zero,Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);
        uiItem.name = "Item_" + i;
        uiItem.gameObject.SetActive(true);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIInventoryItemSpawner();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.LogWarning(transform.name + ": LoadContent", gameObject);
    }

    protected virtual void LoadUIInventoryItemSpawner()
    {
        if (this.inventoryItemSpawner != null) return;
        this.inventoryItemSpawner = transform.GetComponentInChildren<UIInventoryItemSpawner>();
        Debug.LogWarning(transform.name + ": LoadUIInventoryItemSpawner", gameObject);
    }
}
