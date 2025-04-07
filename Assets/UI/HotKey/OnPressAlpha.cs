using Unity.VisualScripting;
using UnityEngine;

public class OnPressAlpha : UIHotkeyAbstract
{

    // Update is called once per frame
    void Update()
    {
        this.CheckAlphaIsPress();
    }

    protected virtual void CheckAlphaIsPress()
    {
        if (InputHokeyManager.Instance.isPress1) this.Press(0);
        if (InputHokeyManager.Instance.isPress2) this.Press(1);
        if (InputHokeyManager.Instance.isPress3) this.Press(2);
        if (InputHokeyManager.Instance.isPress4) this.Press(3);
        if (InputHokeyManager.Instance.isPress5) this.Press(4);
        if (InputHokeyManager.Instance.isPress6) this.Press(5);
        if (InputHokeyManager.Instance.isPress7) this.Press(6);
    }

    protected virtual void Press(int press)
    {
        Debug.Log(press);
        ItemSlot itemSlot = this.uiHotkeyController.itemSlots[press];
        Pressable pressable = itemSlot.GetComponentInChildren<Pressable>();
        if (pressable == null) return;
        pressable.Pressed();
    }
}
