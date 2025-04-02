using UnityEngine;

public class UIHotkeyController : ThanguMonoBehavior
{
    private static UIHotkeyController instance;
    public static UIHotkeyController Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (UIHotkeyController.instance != null) Debug.LogError("Only 1 UIHotkeyController");
        UIHotkeyController.instance = this;
    }
  
}
