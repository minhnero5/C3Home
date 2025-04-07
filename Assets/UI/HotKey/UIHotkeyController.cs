using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class UIHotkeyController : ThanguMonoBehavior
{
    private static UIHotkeyController instance;
    public static UIHotkeyController Instance => instance;

    public List<ItemSlot> itemSlots;

    protected override void Awake()
    {
        base.Awake();
        if (UIHotkeyController.instance != null) Debug.LogError("Only 1 UIHotkeyController");
        UIHotkeyController.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSlots();
    }

    protected virtual void LoadItemSlots()
    {
        if (this.itemSlots.Count > 0) return;
        ItemSlot[] arraySlots = GetComponentsInChildren<ItemSlot>();
        this.itemSlots.AddRange(arraySlots);
        Debug.Log(transform.name + ": LoadItemSlots", gameObject);
    }

}
