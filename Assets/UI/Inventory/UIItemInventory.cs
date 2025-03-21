using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : ThanguMonoBehavior
{

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemNumber;
    public Text ItemNumber => itemNumber;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumber();
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

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemName.text = item.itemProfileSO.itemName;
        this.itemNumber.text = item.itemCount.ToString();
    }
}
