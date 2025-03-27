using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : ThanguMonoBehavior
{

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemNumber;
    public Text ItemNumber => itemNumber;

    [SerializeField] protected Image itemSprite;
    public Image ItemSprite => itemSprite;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumber();
        this.LoadItemSprite();
    }

    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<Text>();
        Debug.Log(gameObject.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadItemNumber()
    {
        if (this.itemNumber != null) return;
        this.itemNumber = transform.Find("ItemCount").GetComponent<Text>();
        Debug.Log(gameObject.name + ": LoadItemNumber", gameObject);
    }

    protected virtual void LoadItemSprite()
    {
        if (this.itemSprite != null) return;
        this.itemSprite = transform.Find("ItemSprite").GetComponent<Image>();
        Debug.Log(gameObject.name + ": LoadItemSprite", gameObject);
    }

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.text = item.itemProfileSO.itemName;
        this.itemNumber.text = item.itemCount.ToString();
        this.itemSprite.sprite = this.itemInventory.itemProfileSO.sprite;
    }
}
