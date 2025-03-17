using UnityEngine;

public class UIInventory : ThanguMonoBehavior
{
    private static UIInventory instance;

    public static UIInventory Instance => instance;

    protected bool isOpen = false;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("There is more EnemySpawner than 1 instance");
        UIInventory.instance = this;

    }
    protected override void Start()
    {
        base.Start();
        //this.Close();
    }

    protected virtual void FixedUpdate()
    {
        this.ShowItem();
    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if(this.isOpen ) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItem()
    {
        if (!this.isOpen) return;
        float itemCount = PlayerController.Instance.CurrentShip.Inventory.Items.Count;
        Debug.Log("itemCount: " + itemCount);
    }
}
