using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class UIHotkeyAbstract : ThanguMonoBehavior
{
    [SerializeField] protected UIHotkeyController uiHotkeyController;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIKeyController();
    }

    protected virtual void LoadUIKeyController()
    {
        if (this.uiHotkeyController != null) return;
        this.uiHotkeyController = transform.parent.GetComponent<UIHotkeyController>();
        Debug.LogWarning(transform.name + ": LoadUIKeyController", gameObject);
    }

}
